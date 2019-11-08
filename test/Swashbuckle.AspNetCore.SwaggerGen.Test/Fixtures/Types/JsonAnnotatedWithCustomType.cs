using Newtonsoft.Json;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test.Fixtures.Types
{
    public class JsonAnnotatedWithCustomType
    {
        [JsonProperty(Required = Required.AllowNull)]
        public CustomDate Date_ReqAllowNull { get; set; }
        [JsonProperty(Required = Required.Always)]
        public CustomDate Date_ReqAlways { get; set; }
        [JsonProperty(Required = Required.Default)]
        public CustomDate Date_ReqDefault { get; set; }
        [JsonProperty(Required = Required.DisallowNull)]
        public CustomDate Date_ReqDisallowNull { get; set; }

        [JsonProperty(Required = Required.Default)]
        public CustomDate? Date_Nullable { get; set; }
    }
}
