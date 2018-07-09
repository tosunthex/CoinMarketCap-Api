using System;
using CryptoCompare.Reposity;

namespace CoinMarketCap
{
    public interface ICoinMarketCapClient:IDisposable
    {
        IGlobalReposity Global { get; }
        IListingsReposity Listing { get; }
        ITickerReposity Ticker { get; }
    }
}