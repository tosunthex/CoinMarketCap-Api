using System;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCap.Parameters;
using Xunit;

namespace CoinMarketCap.Test
{
    public class TickerTests
    {
        private readonly CoinMarketCapClient _client;
        private const int CryptoReturnLimit = 10;
        public TickerTests()
        {
            _client = CoinMarketCapClient.Instance;
        }
        [Fact]
        public void Ticker_Without_Parameters()
        {   
            var response = _client.Ticker.GetTickers();
            Assert.NotNull(response);
            Console.WriteLine(response.Result.Data.Count);
            Assert.Equal(100,response.Result.Data.Count);
        }
        [Fact]
        public async Task Ticker_With_Start_Parameter()
        {
            const int startId = 3;
            var response = await _client.Ticker.GetTickers(startId, CryptoReturnLimit, SortBy.Id, Currency.USD);
            Assert.Equal(response.Data.Values.First().Id, startId);
        }

        [Fact]
        public async Task Ticker_With_Limit_Must_Return_Two_Currency()
        {
            const int cryptoLimit = 2;
            var response = await _client.Ticker.GetTickers(Start.StartId, cryptoLimit, SortBy.Rank, Currency.USD);
            Assert.Equal(2, response.Data.Count);
        }

        [Fact]
        public async Task Ticker_Sort_By_Id()
        {
            var response = await _client.Ticker.GetTickers(Start.StartId, CryptoReturnLimit, SortBy.Id, Currency.USD);
            var responseArray = response.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Id;
                var currentCrypto = responseArray[i].Id;
                Assert.True(prevCrypto <= currentCrypto,
                    $"Sort By Id Error Crypto Id {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public async Task Ticker_Sort_By_Rank()
        {
            var response = await _client.Ticker.GetTickers(Start.StartId, CryptoReturnLimit, SortBy.Rank, Currency.USD);
            var responseArray = response.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Rank;
                var currentCrypto = responseArray[i].Rank;
                Assert.True(prevCrypto <= currentCrypto,
                    $"Sort By Rank Error Crypto Rank {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public async Task Ticker_Sort_By_PercentChange24H()
        {
            var response = await _client.Ticker.GetTickers(Start.StartId, CryptoReturnLimit, SortBy.PercentChange24H, Currency.USD);
            var responseArray = response.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Quotes.Values.First().PercentChange24H;
                var currentCrypto = responseArray[i].Quotes.Values.First().PercentChange24H;
                Assert.True(prevCrypto >= currentCrypto,
                    $"Sort By Percent 24 Hour Error Crypto {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public async Task Ticker_Sort_By_Volume24H()
        {
            var response = await _client.Ticker.GetTickers(Start.StartId, CryptoReturnLimit, SortBy.Volume24H, Currency.USD);
            var responseArray = response.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Quotes.Values.First().Volume24H;
                var currentCrypto = responseArray[i].Quotes.Values.First().Volume24H;
                Assert.True(prevCrypto >= currentCrypto,
                    $"Sort By Volume 24 Hour Error Crypto {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public async Task Ticker_With_Currency_Parameter()
        {
            var response = await _client.Ticker.GetTickers(Start.StartId, CryptoReturnLimit, SortBy.Id, Currency.EUR);
            Assert.Equal(Currency.EUR, response.Data.Values.First().Quotes.Keys.Last());
        }

        [Fact]
        public async Task Ticker_With_Id()
        {
            const int XrpId = 52;
            var response = await _client.Ticker.GetById(XrpId, Currency.BTC);
            Assert.Equal(XrpId, response.Data.Id);
            Assert.Equal(Currency.BTC, response.Data.Quotes.Keys.Last());
        }
    }
}
