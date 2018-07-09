using Newtonsoft.Json;

namespace CoinMarketCap.Model
{
    public class GlobalMetadata
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("error")]
        public object Error { get; set; }
    }
    
}