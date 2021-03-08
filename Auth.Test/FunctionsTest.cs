using Amazon.Lambda.Core;
using AutoFixture;
using Moq;
using Newtonsoft.Json;
using Auth.Application;
using Auth.Domain.Entities;
using System.Collections.Generic;
using Xunit;
using Amazon.Lambda.SQSEvents;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Tests
{
    public class Tests
    {
        private Fixture _fixture;
        private Function _function;

        public Tests()
        {
            _fixture = new Fixture();
            _function = new Function();
        }

        [Fact]
        public void AuthTet()
        {
            var lambdaContext = new Mock<ILambdaContext>();
            var tokenContext = _fixture
                .Build<TokenAuthorizerContext>()
                .With(x => x.AuthorizationToken, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJwZWRyby5ycm1haWFAbGl2ZS5jb20iLCJqdGkiOiJlYTM5ZWQ5Mzk5MGU0ZjYxYjRjMDliYzFkZDNlMGQ0NyIsInVuaXF1ZV9uYW1lIjoicGVkcm8ucnJtYWlhQGxpdmUuY29tIiwiT1JERVJTIjpbIlBPU1QiLCJHRVQiXSwiZXhwIjoxNjE0NjM0MDQ4fQ.V9nZhkpJZlAsmDiGjBgopCszy1Ns37DGlN-e1f_XXhE")
                .With(x => x.MethodArn, "arn:aws:execute-api:us-east-1:277944362602:kenqee79v2/*/POST/accounts/auth")
                .Create();

            _function.FunctionHandler(tokenContext, lambdaContext.Object);
        }
    }
}