using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetfairExt.BFExchange;

namespace BetfairExt.Parsers
{
    public static class AllMarketsParser
    {
        static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static IEnumerable<Market> Parse(string marketData)
        {
            var sanitised = Utils.Sanitize(marketData);

            foreach (var market in sanitised.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var fields = market.Split('~');
                /*
                 * http://bdp.betfair.com/docs/GetAllMarkets.html
                 * Example marketData output
                 * :20158165~Match Odds~O~ACTIVE~1164223800000~\Soccer\Scottish Soccer\Bells League Div 1\Fixtures 22 November \Partick v Clyde~/1/2695886/610072/10551708/10551709/20158165~0~1~GBR~1164192924479~3~1~8737.44~N~N:
                 */
                yield return new Market
                {
                    marketId = int.Parse(fields[0]),
                    name = Utils.Desanitise(fields[1]),
                    marketType = (MarketTypeEnum)Enum.Parse(typeof(MarketTypeEnum), fields[2]),
                    marketStatus = (MarketStatusEnum)Enum.Parse(typeof(MarketStatusEnum), fields[3]),
                    marketTime = Epoch.AddMilliseconds(long.Parse(fields[4])),
                    menuPath = Utils.Desanitise(fields[5]),
                    eventHierarchy = ParseEventHierarchy(fields[6]),
                    // bet delay not present in Market class - should extend? fields[7]
                    licenceId = int.Parse(fields[8]),
                    countryISO3 = Utils.Desanitise(fields[9]),
                    lastRefresh = 0L, // long.Parse(fields[10]), // deprecated
                    runners = new Runner[int.Parse(fields[11])], // no actual runner info, but create array of correct size
                    numberOfWinners = int.Parse(fields[12]),
                    // amount matched not present fields[13]
                    bspMarket = fields[14] == "Y",
                    // turning in-play not presentfields[15]
                };
            }
        }

        private static int?[] ParseEventHierarchy(string hierarchy)
        {
            if (hierarchy == null)
                return null;

            var ids = hierarchy.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return ids.Select(id => (int?)int.Parse(id)).ToArray();
        }
    }
}
