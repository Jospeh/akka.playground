using Akka.Actor;

namespace Triggers.Host
{
    public class StockTrigger : TypedActor, IHandle<StockLooksGood>
    {
        public static Props Create(string hash, Buy bid)
        {
            return Props.Create(() => new StockTrigger(hash, bid));
        }

        private readonly string hash;
        private readonly Buy bid;

        private readonly ActorRef action;
        

        public StockTrigger(string hash, Buy bid)
        {
            this.hash = hash;
            this.action = Context.ActorOf(BuyingSpreeAction.Create(bid));
            this.bid = bid;
        }

        public void Handle(StockLooksGood message)
        {
            if(hash.Equals(message.Symbol))
                action.Tell(bid);
        }
    }
}