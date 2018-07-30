using System;
using System.Net.Http;
using CoinMarketCap.Reposity;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api Client
    /// </summary>
    public class CoinMarketCapClient:ICoinMarketCapClient,IDisposable
    {
        private static readonly Lazy<CoinMarketCapClient> Lazy =
            new Lazy<CoinMarketCapClient>(() => new CoinMarketCapClient());

        private readonly HttpClient _httpClient;
        private bool _isDisposed;


        public CoinMarketCapClient(HttpClientHandler httpClientHandler) => _httpClient = new HttpClient(httpClientHandler,true);

        public CoinMarketCapClient():this(new HttpClientHandler())
        {
        }
        /// <summary>
        /// Gets a Singleton instance of CoinMarketCap Instace
        /// </summary>
        public static CoinMarketCapClient Instance => Lazy.Value;


        public IGlobalReposity Global => new GlobalReposity();
        public IListingsReposity Listing => new ListingReposity();
        public ITickerReposity Ticker => new TickerReposity();

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _isDisposed = true;
        }
    }
}
