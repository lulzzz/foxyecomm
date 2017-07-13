﻿using System;
using System.Text;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FoxyEcomm.Messaging.RabbitMq
{
    public class RabbitMqMessageSubscriber : DisposableObject, IMessageSubscriber
    {
        private readonly string exchangeName;
        private readonly string queueName;
        private readonly IConnection connection;
        private readonly IModel channel;
        private bool disposed;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Initializes a new instance of <c>RabbitMqMessageSubscriber</c> class.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="exchangeName"></param>
        /// <param name="queueName"></param>
        public RabbitMqMessageSubscriber(string uri, string exchangeName, string queueName)
        {
            this.exchangeName = exchangeName;
            this.queueName = queueName;
            var factory = new ConnectionFactory() { Uri = uri, Port = 32771 };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        public void Subscribe()
        {
            channel.ExchangeDeclare(exchange: this.exchangeName, type: "fanout");

            channel.QueueDeclare(queue: this.queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind(queue: this.queueName,
                              exchange: this.exchangeName,
                              routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body;
                var json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                this.OnMessageReceived(new MessageReceivedEventArgs(message));
                channel.BasicAck(e.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: queueName,
                                 noAck: false,
                                 consumer: consumer);
        }

        private void OnMessageReceived(MessageReceivedEventArgs e)
        {
            this.MessageReceived?.Invoke(this, e);
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
    }
}
