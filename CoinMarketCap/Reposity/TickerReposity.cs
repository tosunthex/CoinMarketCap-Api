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
    public class TickerReposity:ITickerReposity
    {
        private readonly HttpClient _restClient;
        private readonly QueryStringService queryStringService;
        private readonly JsonParserService jsonParserService;
        public TickerReposity()
        {
            
            _restClient = new HttpClient {BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
            queryStringService = new QueryStringService();
            jsonParserService = new JsonParserService();
        }

        /*public Task<TickersData> GetTopCrypto()
        {
            const int start = Start.StartId;
            const int limit = Limit.Max;
            const string sort = SortBy.Rank;
            const string convert = Currency.USD;  
            return GetTopCrypto(start,limit,sort,convert);
        }*/

        public async Task<TickersData> GetTickers(int? start = Start.StartId, int? limit = Limit.Max, string sort = SortBy.Rank, string convert = Currency.USD)
        {
            var startParam = start >= 1 ? $"start={start}" : null;
            var limitParam = limit >= 1 ? $"limit={limit}" : null;
            var sortParam = !string.IsNullOrWhiteSpace(sort) ? $"sort={sort}" : null;
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;

            var url = queryStringService.AppendQueryString(Endpoints.Ticker,startParam,limitParam,sortParam,convertParam);
            var response =  await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<TickersData>(response);
        }

        public async Task<TickerData> GetById(int id,string convert)
        {
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;
            var url = queryStringService.AppendQueryString($"{Endpoints.Ticker}/{id}", convertParam);
            var response = await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<TickerData>(response);
        }
    }
}