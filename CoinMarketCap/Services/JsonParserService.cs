using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinMarketCap.Services
{
    public class JsonParserService
    {
        public async Task<T> ParseResponse<T>(HttpResponseMessage httpResponseMessage)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var listingsResponse = JsonConvert.DeserializeObject<T>(responseContent);
            return listingsResponse;
        }
    }
}