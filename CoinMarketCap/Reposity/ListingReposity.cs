using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;
using CoinMarketCap.Services;

namespace CoinMarketCap.Reposity
{
    public class ListingReposity:IListingsReposity
    {
        private readonly HttpClient _restClient;
        public ListingReposity()
        {
            _restClient = new HttpClient{BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
        }
        public async Task<ListingsData> Get()
        {
            var url = QueryStringService.AppendQueryString(Endpoints.Listings,new Dictionary<string, string>());
            var response = await _restClient.GetAsync(url);
            return await JsonParserService.ParseResponse<ListingsData>(response);
        }
    }
}