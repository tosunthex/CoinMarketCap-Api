using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;
using CoinMarketCap.Services;

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
            var url = QueryStringService.AppendQueryString(Endpoints.GlobalData, new Dictionary<string, string>
            {
                { "convert", convert}
            });
            var response = await _restClient.GetAsync(url);
            return await JsonParserService.ParseResponse<GlobalData>(response);
        }
    }
}