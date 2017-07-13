using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Services.Common
{
    public abstract class Microservice : Service
    {
        private readonly ICommandConsumer commandConsumer;
        private readonly IEventConsumer eventConsumer;
        private bool disposed;

        public Microservice(ICommandConsumer commandConsumer, IEventConsumer eventConsumer)
        {
            this.commandConsumer = commandConsumer;
            this.eventConsumer = eventConsumer;
        }

        public ICommandConsumer CommandConsumer => commandConsumer;

        public IEventConsumer EventConsumer => eventConsumer;

        public override void Start(object[] args)
        {
            this.commandConsumer.Subscriber.Subscribe();
            this.eventConsumer.Subscriber.Subscribe();
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    this.commandConsumer.Dispose();
                    this.eventConsumer.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
