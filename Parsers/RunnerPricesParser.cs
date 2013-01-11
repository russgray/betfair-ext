using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BetfairExt.BFExchange;

namespace BetfairExt.Parsers
{
    internal static class RunnerPricesParser
    {
        internal static IEnumerable<RunnerPrices> Parse(IEnumerable<string> runners)
        {
            foreach (string runner in runners)
            {
                var fields = runner.Split('|');

                // Info is in fields[0]
                var info = fields[0].Split('~');

                var allPrices = fields.Length == 3
                                    ? ParseStandardPrices(fields[1], fields[2])
                                    : ParseCompletePrices(fields[1]);

                yield return
                    new RunnerPrices
                    {
                        selectionId = int.Parse(info[0]),
                        sortOrder = int.Parse(info[1]),
                        totalAmountMatched = double.Parse(info[2]),
                        lastPriceMatched = string.IsNullOrEmpty(info[3]) ? 0 : double.Parse(info[3]),
                        handicap = string.IsNullOrEmpty(info[4]) ? 0 : double.Parse(info[4]),
                        reductionFactor = string.IsNullOrEmpty(info[5]) ? 0 : double.Parse(info[5]),
                        vacant = bool.Parse(info[6]),
                        asianLineId = string.IsNullOrEmpty(info[7]) ? 0 : int.Parse(info[7]),
                        farBSP = string.IsNullOrEmpty(info[8]) ? (double?)null : double.Parse(info[8]),
                        nearBSP = string.IsNullOrEmpty(info[9]) ? (double?)null : double.Parse(info[9]),
                        actualBSP = string.IsNullOrEmpty(info[10]) ? (double?)null : double.Parse(info[10]),
                        // Query allPrices for back and lay prices, and sort by price
                        bestPricesToBack =
                            allPrices.Where(p => p.betType == BetTypeEnum.B).OrderBy(p => p.price).ToArray(),
                        bestPricesToLay =
                            allPrices.Where(p => p.betType == BetTypeEnum.L).OrderBy(p => p.price).ToArray(),
                    };
            }
        }

        private static IEnumerable<Price> ParseStandardPrices(string compressedLayPrices, string compressedBackPrices)
        {
            // Remove trailing separators so we don't get an empty element from string.Split
            var trimmedLayPrices = Utils.RemoveSingleTrailingChar(compressedLayPrices, '~');
            var trimmedBackPrices = Utils.RemoveSingleTrailingChar(compressedBackPrices, '~');

            if (string.IsNullOrEmpty(trimmedLayPrices) && string.IsNullOrEmpty(trimmedBackPrices))
                yield break;

            var prices = (trimmedLayPrices + "~" + trimmedBackPrices).Split('~');

            for (var i = 0; i < prices.Length; i += 4 /* 4 elements per runner */)
            {
                var price = double.Parse(prices[i]);
                var available = double.Parse(prices[i + 1]);
                var betType = (BetTypeEnum)Enum.Parse(typeof(BetTypeEnum), prices[i + 2]);
                var depth = int.Parse(prices[i + 3]);

                yield return new Price { amountAvailable = available, betType = betType, price = price, depth = depth };
            }
        }

        private static IEnumerable<Price> ParseCompletePrices(string compressedPrices)
        {
            // Remove trailing separator if it exists, so we don't get an empty element from string.Split
            var trimmed = Utils.RemoveSingleTrailingChar(compressedPrices, '~');

            if (string.IsNullOrEmpty(trimmed))
                yield break;

            var prices = trimmed.Split('~');
            Debug.Assert(prices.Length % 5 == 0);

            for (var i = 0; i < prices.Length; i += 5 /* 5 elements per runner */)
            {
                var price = double.Parse(prices[i]);

                var availToBack = double.Parse(prices[i + 1]);
                if (availToBack > 0.0)
                    yield return new Price { amountAvailable = availToBack, betType = BetTypeEnum.B, price = price };

                var availToLay = double.Parse(prices[i + 2]);
                if (availToLay > 0.0)
                    yield return new Price { amountAvailable = availToLay, betType = BetTypeEnum.L, price = price };

                // TODO Not sure what to do with this data?
                //double bspBack = double.Parse(prices[i + 3]);
                //double bspLay = double.Parse(prices[i + 4]);
            }
        }
    }
}
