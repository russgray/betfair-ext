using System.Collections.Generic;
using System.Linq;
using BetfairExt.BFExchange;

namespace BetfairExt.Parsers
{
    public static class TradedVolumeParser
    {
        public static IEnumerable<CompleteMarketTradedVolume> Parse(string volumeData)
        {
            var runnerData = volumeData.Split(':').Where(v => v != string.Empty);

            foreach (var runner in runnerData)
            {
                var fields = runner.Split('|').ToList();
                var selectionInfo = fields[0].Split('~');

                var totalBspBackMatchedAmount = double.Parse(selectionInfo[3]);
                var totalBspLiabilityMatchedAmount = double.Parse(selectionInfo[4]);

                yield return
                    new CompleteMarketTradedVolume
                    {
                        SelectionID = int.Parse(selectionInfo[0]),
                        AsianLineID = int.Parse(selectionInfo[1]),
                        ActualBSP = double.Parse(selectionInfo[2]),
                        TotalBspBackMatchedAmount = totalBspBackMatchedAmount,
                        TotalBspLiabilityMatchedAmount = totalBspLiabilityMatchedAmount,
                        Prices =
                            ParseVolumeData(fields.GetRange(1, fields.Count - 1), totalBspBackMatchedAmount,
                                            totalBspLiabilityMatchedAmount),
                    };
            }
        }

        private static IEnumerable<VolumeInfo> ParseVolumeData(IEnumerable<string> volumes, double totalBackMatched,
                                                               double totalLiabilityMatched)
        {
            foreach (var v in volumes)
            {
                var fields = v.Split('~');
                yield return new VolumeInfo
                {
                    odds = double.Parse(fields[0]),
                    totalMatchedAmount = double.Parse(fields[1]),
                    totalBspBackMatchedAmount = totalBackMatched,
                    totalBspLiabilityMatchedAmount = totalLiabilityMatched,
                };
            }
        }
    }
}
