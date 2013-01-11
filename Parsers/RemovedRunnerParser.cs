using System.Collections.Generic;

namespace BetfairExt.Parsers
{
    public static class RemovedRunnerParser
    {
        public static IEnumerable<RemovedRunner> Parse(string info)
        {
            if (string.IsNullOrEmpty(info))
                yield break;

            foreach (var removedRunner in info.Split(';'))
            {
                if (string.IsNullOrEmpty(removedRunner)) continue;
                yield return new RemovedRunner(removedRunner.Split(','));
            }
        }
    }
}
