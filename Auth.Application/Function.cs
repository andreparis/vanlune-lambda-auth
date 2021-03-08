using Amazon.Lambda.Core;
using System;
using Auth.Domain.Entities;
using Auth.Application.Application.Services;
using Auth.Domain.Validation;

namespace Auth.Application
{
    public class Function
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public AuthPolicy FunctionHandler(TokenAuthorizerContext input, ILambdaContext context)
        {
            try
            {
                context.Logger.LogLine($"{nameof(input.AuthorizationToken)}: {input.AuthorizationToken}");
                context.Logger.LogLine($"{nameof(input.MethodArn)}: {input.MethodArn}");

                var policyBuilder = UserService
                    .Validade(input.AuthorizationToken, 
                    input.MethodArn,
                    context.Logger);

                var authResponse = policyBuilder.Build();

                return authResponse;
            }
            catch(Exception e)
            {
                if (e is UnauthorizedException)
                    throw;

                context.Logger.LogLine(e.ToString());

                throw new UnauthorizedException();
            }
        }
    }
}
