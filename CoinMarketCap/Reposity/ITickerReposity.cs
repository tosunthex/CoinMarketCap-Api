using System.Threading.Tasks;
using CoinMarketCap.Model;
using CoinMarketCap.Parameters;

namespace CryptoCompare.Reposity
{
    public interface ITickerReposity
    {
        Task<TickersData> GetTickers(int? start = null,int? limit = null,string sort = null,string convert=null );
        Task<TickerData> GetById(int id,string convert);
    }
}