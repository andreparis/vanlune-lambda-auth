using Auth.Domain.Entities;
using Auth.Domain.Messaging;
using Auth.Infraestructure.Logging;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Infrastructure.Messaging
{
    public class AuthRedis : RedisClientHelper<Credentials>, IAuthRedis
    {
        public AuthRedis(IRedisCacheClient cacheClient,
            ILogger logger) : base(cacheClient, logger) { }

        public Credentials GetCredentials(string token)
        {
            return GetFromRedis(string.Concat("user:",token));
        }
    }
}
