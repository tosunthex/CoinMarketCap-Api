using System;
using System.Threading.Tasks;
using Xunit;

namespace CoinMarketCap.Test
{
    public class ListingTest
    {   
        [Fact]
        public async Task Crypto_Listing_Count_Check()
        {
            var client = CoinMarketCapClient.Instance;
            var response = await client.Listing.Get();
            Assert.Equal(response.Data.Count, response.Metadata.NumCryptocurrencies);
        }
    }
}