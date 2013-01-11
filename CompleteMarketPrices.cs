using System.Collections.Generic;
using BetfairExt.BFExchange;
using BetfairExt.Parsers;

namespace BetfairExt
{
    public class CompleteMarketPrices
    {
        public CompleteMarketPrices(string[] marketInfo, IEnumerable<string> runnerInfo)
        {
            MarketID = int.Parse(marketInfo[0]);
            BetDelay = int.Parse(marketInfo[1]);

            RemovedRunnersString = marketInfo[2];
            RemovedRunners = RemovedRunnerParser.Parse(marketInfo[2]);
            Runners = RunnerPricesParser.Parse(runnerInfo);
        }

        public IEnumerable<RunnerPrices> Runners { get; private set; }
        public IEnumerable<RemovedRunner> RemovedRunners { get; private set; }
        public string RemovedRunnersString { get; private set; }
        public int BetDelay { get; private set; }
        public int MarketID { get; private set; }
    }
}
