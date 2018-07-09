using System;
using CoinMarketCap.Reposity;
using CryptoCompare.Reposity;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api Client
    /// </summary>
    public class CoinMarketCapClient:ICoinMarketCapClient
    {
        private static readonly Lazy<CoinMarketCapClient> Lazy =
            new Lazy<CoinMarketCapClient>(() => new CoinMarketCapClient());
        private bool _isDisposed;
        /// <summary>
        /// Gets a Singleton instance of CoinMarketCap Instace
        /// </summary>
        public CoinMarketCapClient()
        {
        }
        public static CoinMarketCapClient Instance => Lazy.Value;

        public IGlobalReposity Global => new GlobalReposity();
        public IListingsReposity Listing => new ListingReposity();
        public ITickerReposity Ticker => new TickerReposity();

        public void Dispose() => this.Dispose(true);

        internal virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }
    }
}
