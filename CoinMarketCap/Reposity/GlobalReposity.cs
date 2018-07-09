using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;
using CoinMarketCap.Services;
using CryptoCompare.Reposity;
using CryptoCompare.Services;

namespace CoinMarketCap.Reposity
{
    public class GlobalReposity:IGlobalReposity
    {
        private readonly HttpClient _restClient;
        public GlobalReposity()
        {
            _restClient = new HttpClient{BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
        }
        public async Task<GlobalData> Get(string convert)
        {
            var queryStringService = new QueryStringService();
            var jsonParserService = new JsonParserService();
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;

            var url = queryStringService.AppendQueryString(Endpoints.GlobalData, convertParam);
            var response = await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<GlobalData>(response);
        }
    }
}