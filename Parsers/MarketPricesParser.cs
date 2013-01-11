using System;
using System.Linq;
using BetfairExt.BFExchange;

namespace BetfairExt.Parsers
{
    public static class MarketPricesParser
    {
        public static MarketPrices Parse(string priceData)
        {
            // Change any escaped separators with a token (I think only 
            // selection names for removed runners are a potential hit)
            var sanitised = Utils.Sanitize(priceData);

            // Split into market data and runner data
            var fields = sanitised.Split(':').ToList();

            // Market info in first field
            var marketInfo = fields[0].Split('~');

            // Runner fields from index 1 to end (including removed runners)
            var runners = fields.GetRange(1, fields.Count - 1);

            // Done. Simple or what? :-)
            return new MarketPrices
            {
                marketId = int.Parse(marketInfo[0]),
                currencyCode = marketInfo[1],
                marketStatus = (MarketStatusEnum)Enum.Parse(typeof(MarketStatusEnum), marketInfo[2]),
                delay = int.Parse(marketInfo[3]),
                numberOfWinners = int.Parse(marketInfo[4]),
                marketInfo = Utils.Desanitise(marketInfo[5]),
                discountAllowed = bool.Parse(marketInfo[6]),
                marketBaseRate = float.Parse(marketInfo[7]),
                lastRefresh = long.Parse(marketInfo[8]),
                removedRunners = marketInfo[9],
                bspMarket = marketInfo[10] == "Y",
                runnerPrices = RunnerPricesParser.Parse(runners).ToArray(),
            };
        }
    }
}
