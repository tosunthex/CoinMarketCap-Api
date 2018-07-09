using Newtonsoft.Json;

namespace CoinMarketCap.Model
{
    public class GlobalData
    {
        [JsonProperty("data")]
        public Global Data { get; set; }
        [JsonProperty("metadata")]
        public GlobalMetadata Metadata { get; set; }
    }
}