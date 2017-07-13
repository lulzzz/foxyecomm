using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Messaging.RabbitMq
{
    public class RabbitMqCommandSender : RabbitMqMessagePublisher, ICommandSender
    {
        public RabbitMqCommandSender(string uri, string exchangeName)
            : base(uri, exchangeName)
        { }

    }
}
