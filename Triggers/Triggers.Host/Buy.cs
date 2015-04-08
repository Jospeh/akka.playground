using System;

namespace Triggers.Host
{
    public class Buy
    {
        public Buy(string symbol, double startBid, double endBid, TimeSpan duration)
        {
            Symbol = symbol;
            StartBid = startBid;
            EndBid = endBid;
            Duration = duration;
        }

        public string Symbol { get; private set; }
        public double StartBid { get; private set; }
        public double EndBid { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}