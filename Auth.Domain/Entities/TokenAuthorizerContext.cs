using Newtonsoft.Json;

namespace Auth.Domain.Entities
{
    public class TokenAuthorizerContext
    {
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "AuthorizationToken")]
        public string Authorization { get; set; }
        [JsonProperty(PropertyName = "MethodArn")]
        public string MethodArn { get; set; }
    }
}
