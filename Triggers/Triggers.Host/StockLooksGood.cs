namespace Triggers.Host
{
    public class StockLooksGood
    {
        public StockLooksGood(string tvcHash)
        {
            Symbol = tvcHash;
        }

        public string Symbol { get; private set; }
    }
}