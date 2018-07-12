using System.Threading.Tasks;
using CoinMarketCap.Model;

namespace CryptoCompare.Reposity
{
    public interface IGlobalReposity
    {
        /// <summary>
        /// Returns the global data found at the top of coinmarketcap.com
        /// </summary>
        /// <param name="convert">Return pricing info in term of another currency</param>
        /// <returns></returns>
        Task<GlobalData> Get(string convert);
    }
}