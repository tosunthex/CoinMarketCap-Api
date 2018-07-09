using System.Threading.Tasks;
using CoinMarketCap.Model;

namespace CryptoCompare.Reposity
{
    public interface IListingsReposity
    {
        Task<ListingsData> Get();
    }
}