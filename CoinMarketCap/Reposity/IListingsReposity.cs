using System.Threading.Tasks;
using CoinMarketCap.Model;

namespace CoinMarketCap.Reposity
{
    public interface IListingsReposity
    {
        /// <summary>
        /// Returns all active cryptocurrency listings in one call
        /// </summary>
        /// <returns></returns>
        Task<ListingsData> Get();
    }
}