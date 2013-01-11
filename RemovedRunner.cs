using System;

namespace BetfairExt
{
    public class RemovedRunner
    {
        public RemovedRunner(string[] data)
        {
            Name = Utils.Desanitise(data[0]);

            // Grr, have to provide a date part to the parser
            var dt = string.Format("{0:yyyy/MM/dd} {1}", DateTime.Now, data[1].Replace('.', ':'));
            TimeRemoved = DateTime.Parse(dt).ToLocalTime().TimeOfDay;

            AdjustmentFactor = data[2] + "%";
        }

        public string AdjustmentFactor { get; set; }
        public TimeSpan TimeRemoved { get; set; }
        public string Name { get; set; }
    }
}
