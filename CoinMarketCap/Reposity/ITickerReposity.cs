using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;

namespace CryptoCompare.Reposity
{
    public interface ITickerReposity
    {
        /// <summary>
        /// Returns cryptocurrency ticker data in order of rank
        /// </summary>
        /// <param name="start">return results starting from the specified number (default is 1)</param>
        /// <param name="limit">return a maximum of [limit] results (default is 100; max is 100)</param>
        /// <param name="sort">return results sorted by [sort] . Possible values are id, rank, volume_24h, and percent_change_24h (default is rank)</param>
        /// <param name="convert">return pricing info in terms of another currency</param>
        /// <returns></returns>
        Task<TickersData> GetTickers(int? start = null,int? limit = null,string sort = null,string convert=null );
        Task<TickerData> GetById(int id,string convert);
    }
}