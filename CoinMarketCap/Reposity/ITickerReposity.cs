using System.Threading.Tasks;
using CoinMarketCap.Model;

namespace CoinMarketCap.Reposity
{
    public interface ITickerReposity
    {
        /// <summary>
        /// This endpoint displays cryptocurrency ticker data in order of rank. The maximum number of results per call is 100. Pagination is possible by using the 
        /// </summary>
        /// <returns></returns>
        Task<TickersData> GetTickers();

        /// <summary>
        /// This endpoint displays cryptocurrency ticker data in order of rank. The maximum number of results per call is 100. Pagination is possible by using the 
        /// </summary>
        /// <param name="start">Return results starting from the specified number (default is 1)</param>
        /// <param name="limit">Return a maximum of [limit] results (default is 100; max is 100)</param>
        /// <param name="sort">Return results sorted by [sort] . Possible values are id, rank, volume_24h, and percent_change_24h (default is rank)</param>
        /// <param name="convert">Return pricing info in terms of another currency</param>
        /// <returns></returns>
        Task<TickersData> GetTickers(int? start,int? limit,string sort,string convert);

        /// <summary>
        /// This endpoint displays ticker data for a specific cryptocurrency. Use the "id" field from the Listings endpoint in the URL
        /// </summary>
        /// <returns></returns>
        Task<TickerData> GetById();

        /// <summary>
        /// This endpoint displays ticker data for a specific cryptocurrency. Use the "id" field from the Listings endpoint in the URL
        /// </summary>
        /// <param name="id">Cryptocurrency Id</param>
        /// <param name="convert">Return pricing info in terms of another currency</param>
        /// <returns></returns>
        Task<TickerData> GetById(int id,string convert);
    }
}