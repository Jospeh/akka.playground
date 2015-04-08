using System;
using System.Linq;
using Akka.Actor;

namespace Triggers.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new actor system (a container for your actors)
            var system = ActorSystem.Create("Trigger");
            //create your actor and get a reference to it.
            //this will be an "ActorRef", which is not a 
            //reference to the actual actor instance
            //but rather a client or proxy to it
            var super = system.ActorOf<TriggerSuper>();

            Enumerable.Range(1, 10).Select(x =>
            {
                super.Tell(new CreateTrigger(x.ToString(), Bid(x)));
                return x;
            }).ToList();

            Enumerable.Range(1, 10).Select(x =>
            {
                super.Tell(new StockLooksGood(x.ToString()));
                return x;
            }).ToList();
   
            super.Tell("done");
            //this prevents the app from exiting
            //Before the async work is done
            Console.ReadLine();
        }

        private static Buy Bid(int x)
        {
            return new Buy((x * 1000).ToString(), ((double)x) + .5, ((double)x) - .5, TimeSpan.FromSeconds(x));
        }
    }
}
