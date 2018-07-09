using Newtonsoft.Json;

namespace CoinMarketCap.Model
{
    public class Listings
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }
    }
}