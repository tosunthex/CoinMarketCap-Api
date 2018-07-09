using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCap.Model
{
    public class ListingsData
    {
        [JsonProperty("data")]
        public List<Listings> Data { get; set; }
        [JsonProperty("metadata")]
        public ListingsMetadata Metadata { get; set; }
    }
}