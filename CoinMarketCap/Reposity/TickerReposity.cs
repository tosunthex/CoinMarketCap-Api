using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;
using CoinMarketCap.Services;

namespace CoinMarketCap.Reposity
{
    public class TickerReposity:ITickerReposity
    {
        private readonly HttpClient _restClient;
        public TickerReposity()
        {
            _restClient = new HttpClient {BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
        }

        public async Task<TickersData> GetTickers()
        {
            var url = QueryStringService.AppendQueryString(Endpoints.Ticker, new Dictionary<string, string>());
            var response = await _restClient.GetAsync(url);
            return await JsonParserService.ParseResponse<TickersData>(response);
        }

        public async Task<TickersData> GetTickers(int? start, int? limit, string sort, string convert)
        {
            var url = QueryStringService.AppendQueryString(Endpoints.Ticker,new Dictionary<string, string>
            {
                {"start",start >= 1 ? start.ToString() : null },
                {"limit",limit >= 1 ? limit.ToString() : null },
                {"sort",sort },
                {"convert",convert }
            });
            var response =  await _restClient.GetAsync(url);
            return await JsonParserService.ParseResponse<TickersData>(response);
        }

        public Task<TickerData> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task<TickerData> GetById(int id,string convert)
        {
            var url = QueryStringService.AppendQueryString($"{Endpoints.Ticker}/{id}", new Dictionary<string, string>
            {
                {"convert",convert }
            });
            var response = await _restClient.GetAsync(url);
            return await JsonParserService.ParseResponse<TickerData>(response);
        }
    }
}