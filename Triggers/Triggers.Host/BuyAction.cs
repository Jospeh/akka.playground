using System;
using Akka;
using Akka.Actor;
using Akka.Dispatch.SysMsg;
using Newtonsoft.Json;

namespace Triggers.Host
{
    public class BuyingSpreeAction : TypedActor, IHandle<Buy>,  IHandle<ReceiveTimeout>
    {
        private readonly Buy bid;

        public static Props Create(Buy bid)
        {
            return Props.Create(() => new BuyingSpreeAction(bid));
        }

        public BuyingSpreeAction(Buy  bid)
        {
            this.bid = bid;
        }

        public void Handle(Buy message)
        {
            base.SetReceiveTimeout(message.Duration);
            Console.WriteLine("Buying: {0}", JsonConvert.SerializeObject(message));
        }

        public void Handle(ReceiveTimeout message)
        {
            base.SetReceiveTimeout(null);
            Console.WriteLine("Selling: {0}", JsonConvert.SerializeObject(bid));
        }
    }
}