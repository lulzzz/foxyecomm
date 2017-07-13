using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Messaging.RabbitMq
{
    public class RabbitMqEventPublisher : RabbitMqMessagePublisher, IEventPublisher
    {
        public RabbitMqEventPublisher(string uri, string exchangeName)
            : base(uri, exchangeName)
        { }
    }
}
