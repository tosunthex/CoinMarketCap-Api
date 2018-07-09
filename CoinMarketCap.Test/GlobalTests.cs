using System.Threading.Tasks;
using CoinMarketCap.Parameters;
using Xunit;

namespace CoinMarketCap.Test
{
    public class GlobalTests
    {
        [Fact]
        public async Task Global_Return_Success()
        {
            var _client = CoinMarketCapClient.Instance;
            var response = await _client.Global.Get(Currency.USD);
            Assert.NotNull(response);
        }
    }
}