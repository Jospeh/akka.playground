using Akka.Actor;

namespace Triggers.Host
{
    public class TriggerSuper : TypedActor, IHandle<CreateTrigger>, IHandle<StockLooksGood>
    {
        public void Handle(CreateTrigger message)
        {
            Context.ActorOf(StockTrigger.Create(message.Symbol, message.Bid));
        }

        public void Handle(StockLooksGood message)
        {
            foreach (var actor in Context.GetChildren())            
                actor.Tell(message);            
        }
    }
}