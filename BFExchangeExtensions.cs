using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetfairExt.BFExchange;

namespace BetfairExt
{
    public class FullMarket
    {
        public APIResponseHeader Header { get; set; }
        public Market Market { get; set; }
        public MarketPrices Prices { get; set; }
    }

    static class DecimalEnumerable
    {
        public static IEnumerable<decimal> Range(decimal start, decimal stop, decimal step)
        {
            var curr = start;
            while (curr < stop)
            {
                yield return curr;
                curr += step;
            }
        }
    }

    public static class Data
    {
        public static decimal[] PriceLadder { get; private set; }

        static Data()
        {
            var ladder = new List<decimal>();
            ladder.AddRange(DecimalEnumerable.Range(1.01m, 2m, 0.01m));
            ladder.AddRange(DecimalEnumerable.Range(2m, 3m, 0.02m));
            ladder.AddRange(DecimalEnumerable.Range(3m, 4m, 0.05m));
            ladder.AddRange(DecimalEnumerable.Range(4m, 6m, 0.1m));
            ladder.AddRange(DecimalEnumerable.Range(6m, 10m, 0.2m));
            ladder.AddRange(DecimalEnumerable.Range(10m, 20m, 0.5m));
            ladder.AddRange(DecimalEnumerable.Range(20m, 30m, 1m));
            ladder.AddRange(DecimalEnumerable.Range(30m, 50m, 2m));
            ladder.AddRange(DecimalEnumerable.Range(50m, 100m, 5m));
            ladder.AddRange(DecimalEnumerable.Range(100m, 1001m, 10m));

            PriceLadder = ladder.ToArray();
        }

    }

    public static class BFExchangeExtensions
    {
        public static APIRequestHeader CreateHeader(this BFExchangeServiceClient client, string sessionToken)
        {
            return new APIRequestHeader { sessionToken = sessionToken, clientStamp = DateTime.Now.Ticks };
        }

        public static IEnumerable<GetMarketResp> GetMarkets(this BFExchangeServiceClient client, string sessionToken, params int[] marketIDs)
        {
            return marketIDs.AsParallel().Select(id =>
                {
                    return client.getMarket(new GetMarketReq
                    {
                        header = client.CreateHeader(sessionToken),
                        marketId = id,
                    });
                });
        }

        public static FullMarket GetFullMarket(this BFExchangeServiceClient client, string sessionToken, int marketID)
        {
            var marketTask = client.CreateGetMarketTask(new GetMarketReq { header = client.CreateHeader(sessionToken), marketId = marketID });
            var pricesTask = client.CreateGetMarketPricesTask(new GetMarketPricesReq { header = client.CreateHeader(sessionToken), marketId = marketID });
            Task.WaitAll(marketTask, pricesTask);

            return new FullMarket
            {
                Header = marketTask.Result.header,
                Market = marketTask.Result.market,
                Prices = pricesTask.Result.marketPrices,
            };
        }

        public static IEnumerable<GetMarketPricesResp> GetMarketPrices(this BFExchangeServiceClient client, string sessionToken, params int[] marketIDs)
        {
            return marketIDs.AsParallel().Select(id =>
            {
                return client.getMarketPrices(new GetMarketPricesReq
                {
                    header = client.CreateHeader(sessionToken),
                    marketId = id,
                });
            });
        }

        public static IEnumerable<Market> ParseAllMarkets(this BFExchangeServiceClient client, string marketData)
        {
            return null;
        }

        public static double? CalculateBackOverround(this MarketPrices marketPrices)
        {
            return CalculateOverround(marketPrices.runnerPrices, prices => prices.bestPricesToBack);
        }

        public static double? CalculateLayOverround(this MarketPrices marketPrices)
        {
            return CalculateOverround(marketPrices.runnerPrices, prices => prices.bestPricesToLay);
        }

        private static double? CalculateOverround(IEnumerable<RunnerPrices> runnerPrices, Func<RunnerPrices, Price[]> getBestPrices)
        {
            double overround = 0.0;
            foreach (var runner in runnerPrices)
            {
                var prices = getBestPrices(runner);
                if (prices != null && prices.Length > 0)
                    overround += (100.0 / prices[0].price);
                else
                    return null;
            }
            return overround - 100.0;
        }

        private static Task<GetMarketResp> CreateGetMarketTask(this BFExchangeServiceClient client, GetMarketReq req)
        {
            return Task<GetMarketResp>.Factory.FromAsync<GetMarketReq>(
                client.BegingetMarket, client.EndgetMarket, req, null);
        }

        private static Task<GetMarketPricesResp> CreateGetMarketPricesTask(this BFExchangeServiceClient client, GetMarketPricesReq req)
        {
            return Task<GetMarketPricesResp>.Factory.FromAsync<GetMarketPricesReq>(
                client.BegingetMarketPrices, client.EndgetMarketPrices, req, null);
        }
    }
}
