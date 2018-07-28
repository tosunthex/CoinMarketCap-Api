using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CoinMarketCap.Services
{
    public class QueryStringService
    {
        public static string AppendQueryString(string path, Dictionary<string, string> parameter)
        {
            var urlParameters = new List<string>();
            foreach (var par in parameter)
            {
                urlParameters.Add(string.IsNullOrWhiteSpace(par.Value) ? null : $"{par.Key}={par.Value}");
            }

            var encodedParams = urlParameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(WebUtility.HtmlEncode)
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();

            return encodedParams.Length > 0 ? $"{path}{string.Join(string.Empty, encodedParams)}" : path;
        }
    }
}