namespace CoinMarketCap.Parameters
{
    public static class SortBy
    {
        /// <summary>
        /// Sort By Id
        /// </summary>
        public static string Id => "id";
        /// <summary>
        /// Sort By Rank
        /// </summary>
        public static string Rank => "rank";
        /// <summary>
        /// Sort By Volume Last 24 Hour
        /// </summary>
        public static string Volume24H => "volume_24h";
        /// <summary>
        /// Sort By Percent Change Last 24 Hour
        /// </summary>
        public static string PercentChange24H => "percent_change_24h";
    }
}