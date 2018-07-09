using System.Threading.Tasks;
using CoinMarketCap.Model;

namespace CryptoCompare.Reposity
{
    public interface IGlobalReposity
    {
        Task<GlobalData> Get(string convert);
    }
}