using Newtonsoft.Json;

namespace CoinMarketCap.Model
{
    public class TickerData
    {
        [JsonProperty("data")]
        public Ticker Data { get; set; }

        [JsonProperty("metadata")]
        public TickerMetadata TickerMetadata { get; set; }
    }
}