using System.Text;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace FoxyEcomm.Messaging.RabbitMq
{
    public abstract class RabbitMqMessagePublisher : DisposableObject, IMessagePublisher
    {
        private readonly string exchangeName;
        private readonly IConnection connection;
        private readonly IModel channel;
        private bool disposed;

        protected RabbitMqMessagePublisher(string uri, string exchangeName)
        {
            this.exchangeName = exchangeName;
            var factory = new ConnectionFactory() { Uri = uri, Port = 32771 };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    this.channel.Dispose();
                    this.connection.Dispose();
                    disposed = true;
                }
            }
        }

        public void Publish<TMessage>(TMessage message)
        {
            channel.ExchangeDeclare(exchange: this.exchangeName, type: "fanout");

            var json = JsonConvert.SerializeObject(message, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var bytes = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: this.exchangeName, routingKey: "", basicProperties: null, body: bytes);
        }
    }
}
