namespace Triggers.Host
{
    public class CreateTrigger
    {
        public CreateTrigger(string symbol, Buy bid)
        {
            Symbol = symbol;
            Bid = bid;
        }

        public string Symbol { get; private set; }
        public Buy Bid { get; private set; }
    }
}