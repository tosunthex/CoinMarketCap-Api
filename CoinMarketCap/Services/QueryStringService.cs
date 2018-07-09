using System.Linq;

namespace CoinMarketCap.Services
{
    public class QueryStringService
    {
        public string AppendQueryString(string segment, params string[] parameters)
        {
            var encodedParams = parameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(System.Net.WebUtility.HtmlEncode)
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();

            return encodedParams.Length > 0 ? $"{segment}{string.Join(string.Empty, encodedParams)}" : segment;
        }
    }
}