using Newtonsoft.Json;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test.Fixtures.Types
{
    public class NullableValueType
    {
        public int? IntVal_Nullable { get; set; }
        public int IntVal { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int IntVal_JsonAllowNull { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int IntVal_JsonAlways { get; set; }
        [JsonProperty(Required = Required.Default)]
        public int IntVal_JsonDefault { get; set; }
        [JsonProperty(Required = Required.DisallowNull)]
        public CustomDate IntVal_JsonDisallowNull { get; set; }
    }
}
