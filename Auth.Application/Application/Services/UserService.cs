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
                token = token.Replace("Bearer ","");
                var xApiTokenChar = new char[1];
                token.CopyTo(token.Length - 1, xApiTokenChar, 0, 1);
                token = token[0..^1];
                var xApiToken = xApiTokenChar.FirstOrDefault().ToString();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;

                var methodArn = ApiGatewayArn.Parse(method);
                var apiOptions = new ApiOptions(methodArn.Region, methodArn.RestApiId, methodArn.Stage);
                var principalId = tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)
                    .Value + "|" +
                    tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.Jti)
                    .Value;
                var roleId = tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.Sub)
                    .Value;
                var userId = tokenS
                    .Claims
                    .First(claim => claim.Type == JwtRegisteredClaimNames.Sid)
                    .Value;

                var policyBuilder = new AuthPolicyBuilder(principalId, methodArn.AwsAccountId, apiOptions);
                var permissionKey = string.Concat(methodArn.Verb.ToLowerInvariant(), "#", methodArn.Resource).ToLowerInvariant();

                if (!Permission.Claim.ContainsKey(permissionKey) ||
                    string.IsNullOrEmpty(roleId) ||
                    (roleId == "1" &&
                    userId != xApiToken))
                {
                    policyBuilder.DenyMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);
                    return policyBuilder;
                }

                var claim = Permission.Claim[permissionKey];
                var isValid =
                    tokenS.Claims.Any(x =>
                    x.Type.ToLowerInvariant().Equals(methodArn.Resource) &&
                    x.Value.Equals(claim));

                logger.LogLine($"User {userId} is auth {isValid}");

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
