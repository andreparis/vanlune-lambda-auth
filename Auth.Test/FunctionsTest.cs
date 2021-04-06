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
                .With(x => x.Authorization, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIiwianRpIjoiMDQwMDczMjAxZmQ1NGVkZDgxNDgyYmIzNWY2ZWFkNDkiLCJ1bmlxdWVfbmFtZSI6ImFuZHJlcGFyaXMuY29tcEBnbWFpbC5jb20iLCJzaWQiOiI1Iiwib3JkZXJzIjpbIkdFVCIsIlBPU1QiLCJQVVQiXSwiYWNjb3Vuc3RzL3JvbGVzIjoiUE9TVCIsImFjY291bnN0cy9yb2xlcy9wYXRjaCI6IlBPU1QiLCJhY2NvdW5zdHMvcm9sZXMvY2xhaW1zL3BhdGNoIjoiUE9TVCIsImFjY291bnN0cy9jbGFpbXMiOiJQT1NUIiwiYWNjb3Vuc3RzL2NoYW5nZXBhc3Nvd3JkIjoiUE9TVCIsImFjY291bnN0cyI6WyJQT1NUIiwiUFVUIiwiREVMRVRFIl0sInByb2R1Y3RzIjpbIlBPU1QiLCJQVVQiLCJERUxFVEUiLCJHRVQiXSwicHJvZHVjdHMvY2F0ZWdvcnkiOlsiUE9TVCIsIkdFVCJdLCJwcm9kdWN0cy90YWdzIjpbIlBPU1QiLCJHRVQiXSwicHJvZHVjdHMvdmFyaWFudHMiOlsiUE9TVCIsIkdFVCJdLCJvcmRlcnMvdXNlciI6IkdFVCIsIm9yZGVycy9zdGF0dXMiOiJHRVQiLCJvcmRlcnMvdXNlci9lbWFpbCI6IkdFVCIsImV4cCI6MTYxNTc2ODc3MiwiaXNzIjoiUExBWUVSMiIsImF1ZCI6IlBMQVlFUjIifQ.T3n-nI-DwpCuZJ9D9LfmO37ZGP-o5VWwRcaOS9wpmLM5")
                .With(x => x.MethodArn, "arn:aws:execute-api:us-east-1:277944362602:kenqee79v2/*/POST/accounts/auth")
                .Create();

            _function.FunctionHandler(tokenContext, lambdaContext.Object);
        }
    }
}