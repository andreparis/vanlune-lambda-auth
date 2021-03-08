using Amazon.Lambda.Core;
using Auth.Application.Application.Base;
using Auth.Domain.Constants;
using Auth.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Auth.Application.Application.Services
{
    public static class UserService
    {
        public static AuthPolicyBuilder Validade(string token, 
            string method,
            ILambdaLogger logger)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;

                logger.LogLine($"token is {token}");

                var principalId = tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)
                    .Value + "|" +
                    tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.Jti)
                    .Value;
                var methodArn = ApiGatewayArn.Parse(method);
                var apiOptions = new ApiOptions(methodArn.Region, methodArn.RestApiId, methodArn.Stage);

                logger.LogLine($"{methodArn.Region} {methodArn.RestApiId} {methodArn.Stage} {methodArn.Resource}");

                var policyBuilder = new AuthPolicyBuilder(principalId, methodArn.AwsAccountId, apiOptions);

                var permissionKey = string.Concat(methodArn.Verb, "#", methodArn.Resource).ToLowerInvariant();

                if (!Permission.Claim.ContainsKey(permissionKey))
                {
                    policyBuilder.DenyMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);
                    return policyBuilder;
                }

                var claim = Permission.Claim[permissionKey];
                var isValid =
                    tokenS.Claims.Any(x =>
                    x.Type.ToLowerInvariant().Equals(methodArn.Resource) &&
                    x.Value.Equals(claim));

                if (tokenS.ValidTo < DateTime.Now)
                    policyBuilder.DenyAllMethods();
                if (isValid)
                    policyBuilder.AllowMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);
                else
                    policyBuilder.DenyMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);

                return policyBuilder;
            }
            catch(Exception e)
            {
                logger.LogLine($"Error {e.Message} at {e.StackTrace}");

                return default;
            }
        }
    }
}
