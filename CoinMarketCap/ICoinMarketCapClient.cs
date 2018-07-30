using System;
using CoinMarketCap.Reposity;

namespace CoinMarketCap
{
    public interface ICoinMarketCapClient
    {
        IGlobalReposity Global { get; }
        IListingsReposity Listing { get; }
        ITickerReposity Ticker { get; }
    }
}