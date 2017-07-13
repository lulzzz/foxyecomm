using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Orm.Interfaces;
using FoxyEcomm.Services.Common.Exceptions;
using Microsoft.Owin.Logging;

namespace FoxyEcomm.Services.Common
{
    public abstract class MicroserviceRegister<TService> : Module
        where TService : Microservice
    {
        private readonly FoxyEcommConfiguration configuration;

        protected MicroserviceRegister(FoxyEcommConfiguration configuration)
        {
            this.configuration = configuration;
        }


        protected ServiceElement ThisConfiguration => this.configuration.Services.GetItemByKey(typeof(TService).FullName);

        protected IDomainRepository ResolveGlobalDomainRepository(IComponentContext context) => context.Resolve<IDomainRepository>();

        protected ICommandSender ResolveGlobalCommandSender(IComponentContext context) => context.Resolve<ICommandSender>();

        protected IEventPublisher ResolveGlobalEventPublisher(IComponentContext context) => context.Resolve<IEventPublisher>();

        protected IDapperRepository ResolveDataProvider(IComponentContext context) => context.Resolve<IEnumerable<Lazy<IDapperRepository, NamedMetadata>>>().First(p => p.Metadata.Name == $"{ThisConfiguration.Type}.DataProvider").Value;
      
        protected ILogger ResolveLogProvider(IComponentContext context) => context.Resolve<IEnumerable<Lazy<ILogger, NamedMetadata>>>().First(p => p.Metadata.Name == $"{ThisConfiguration.Type}.LogProvider").Value;

        protected virtual Func<IComponentContext, IDapperRepository> DataProviderInitializer => null;
        
        

        protected virtual IEnumerable<Func<IComponentContext, ICommandHandler>> CommandHandlersInitializer => null;

        protected virtual IEnumerable<Func<IComponentContext, IDomainEventHandler>> EventHandlersInitializer => null;

        protected abstract Func<ICommandConsumer, IEventConsumer, TService> ServiceInitializer { get; }

        protected override void Load(ContainerBuilder builder)
        {
            this.RegisterDataProvider(builder, this.DataProviderInitializer);
            this.RegisterCommandHandlers(builder, this.CommandHandlersInitializer);
            this.RegisterEventHandlers(builder, this.EventHandlersInitializer);
            this.RegisterLocalCommandConsumer(builder);
            this.RegisterLocalEventConsumer(builder);
            this.RegisterService(builder, this.ServiceInitializer);

            base.Load(builder);
        }


        private void RegisterDataProvider(ContainerBuilder builder,
            Func<IComponentContext, IDapperRepository> initializer)
        {
            if (initializer != null)
            {
                builder
                    .Register(x => initializer(x))
                    .As<IDapperRepository>()
                    .WithMetadata<NamedMetadata>(x => x.For(y => y.Name, $"{ThisConfiguration.Type}.DataProvider"));
            }
        }
        

        private void RegisterCommandHandlers(ContainerBuilder builder, 
            IEnumerable<Func<IComponentContext, ICommandHandler>> initializer)
        {
            if (initializer != null)
            {
                foreach (var value in initializer)
                {
                    builder.Register(x => value(x))
                        .Named<ICommandHandler>($"{ThisConfiguration.Type}.CommandHandlers");
                }
            }
        }

        private void RegisterEventHandlers(ContainerBuilder builder,
            IEnumerable<Func<IComponentContext, IDomainEventHandler>> initializer)
        {
            if (initializer != null)
            {
                foreach (var value in initializer)
                {
                    builder.Register(x => value(x))
                        .Named<IDomainEventHandler>($"{ThisConfiguration.Type}.EventHandlers");
                }
            }
        }

        private void RegisterLocalCommandConsumer(ContainerBuilder builder)
        {
            var commandQueueConnectionUri = ThisConfiguration?.LocalCommandQueue?.ConnectionUri;
            var commandQueueExchangeName = ThisConfiguration?.LocalCommandQueue?.ExchangeName;
            var commandQueueName = ThisConfiguration?.LocalCommandQueue?.QueueName;

            if (string.IsNullOrEmpty(commandQueueConnectionUri) ||
                string.IsNullOrEmpty(commandQueueExchangeName) ||
                string.IsNullOrEmpty(commandQueueName))
            {
                throw new ServiceRegistrationException("Either of the settings for Command Queue is empty (HostName, ExchangeName or QueueName).");
            }

            Func<IComponentContext, IEnumerable<ICommandHandler>> commandHandlersResolver = (context) =>
            {
                object result;
                if (context.TryResolveNamed($"{ThisConfiguration.Type}.CommandHandlers", typeof(IEnumerable<ICommandHandler>), out result))
                {
                    return (IEnumerable<ICommandHandler>)result;
                }
                return null;
            };

            builder
                .Register(x => new CommandConsumer(x.ResolveNamed<IMessageSubscriber>("CommandSubscriber",
                                new NamedParameter("uri", commandQueueConnectionUri), 
                                new NamedParameter("exchangeName", commandQueueExchangeName), 
                                new NamedParameter("queueName", commandQueueName)
                            ),
                        commandHandlersResolver(x)))
                .Named<ICommandConsumer>($"{ThisConfiguration.Type}.LocalCommandConsumer");
        }

        private void RegisterLocalEventConsumer(ContainerBuilder builder)
        {
            var eventQueueConnectionUri = ThisConfiguration?.LocalEventQueue?.ConnectionUri;
            var eventQueueExchangeName = ThisConfiguration?.LocalEventQueue?.ExchangeName;
            var eventQueueName = ThisConfiguration?.LocalEventQueue?.QueueName;

            if (string.IsNullOrEmpty(eventQueueConnectionUri) ||
                string.IsNullOrEmpty(eventQueueExchangeName) ||
                string.IsNullOrEmpty(eventQueueName))
            {
                throw new ServiceRegistrationException("Either of the settings for Command Queue is empty (HostName, ExchangeName or QueueName).");
            }

            Func<IComponentContext, IEnumerable<IDomainEventHandler>> eventHandlersResolver = (context) =>
            {
                object result;
                if (context.TryResolveNamed($"{ThisConfiguration.Type}.EventHandlers", typeof(IEnumerable<IDomainEventHandler>), out result))
                {
                    return (IEnumerable<IDomainEventHandler>)result;
                }
                return null;
            };

            builder
                .Register(x => new EventConsumer(x.ResolveNamed<IMessageSubscriber>("EventSubscriber",
                                new NamedParameter("uri", eventQueueConnectionUri),
                                new NamedParameter("exchangeName", eventQueueExchangeName),
                                new NamedParameter("queueName", eventQueueName)
                            ),
                            eventHandlersResolver(x)))
                .Named<IEventConsumer>($"{ThisConfiguration.Type}.LocalEventConsumer");
        }

        private void RegisterService(ContainerBuilder builder,
            Func<ICommandConsumer, IEventConsumer, TService> serviceInitializer)
        {
            Func<IComponentContext, ICommandConsumer> localCommandConsumerResolver = context =>
                context.ResolveNamed<ICommandConsumer>($"{ThisConfiguration.Type}.LocalCommandConsumer");
            Func<IComponentContext, IEventConsumer> localEventConsumerResolver = context =>
                context.ResolveNamed<IEventConsumer>($"{ThisConfiguration.Type}.LocalEventConsumer");

            builder.Register(x => serviceInitializer(localCommandConsumerResolver(x), localEventConsumerResolver(x)))
                .As<IService>()
                .SingleInstance();
        }

        
    }
}
