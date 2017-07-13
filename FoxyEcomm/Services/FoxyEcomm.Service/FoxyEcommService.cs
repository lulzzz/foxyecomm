using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using FoxyEcomm.Common.Exceptions;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.DomainRepositories.MongoDb.Implementations;
using FoxyEcomm.DomainRepositories.MongoDb.Models;
using FoxyEcomm.Messaging.RabbitMq;
using FoxyEcomm.Services.Common;
using FoxyEcomm.Services.Common.Attributes;
using FoxyEcomm.Services.Common.Handlers;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace FoxyEcomm.Service
{
    internal sealed class FoxyEcommService : Common.Models.Service
    {
        private readonly FoxyEcommConfiguration _configuration = FoxyEcommConfiguration.Instance;

        private const string SearchPath = "services";
        private static readonly List<IService> MicroServices = new List<IService>();

        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.Name);

        private void DiscoverServices(ContainerBuilder builder)
        {
            var searchFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SearchPath);
            foreach (var file in Directory.EnumerateFiles(searchFolder, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    var exportedTypes = assembly.GetExportedTypes();
                    var microserviceRegisterType = exportedTypes.FirstOrDefault(x =>
                    {
                        return x.BaseType != null && (x.IsSubclassOf(typeof(Autofac.Module)) &&
                                                      x.BaseType.GetGenericTypeDefinition() ==
                                                      typeof(MicroserviceRegister<>));
                    });
                    if (microserviceRegisterType != null)
                    {
                        if (microserviceRegisterType.BaseType != null)
                        {
                            var registeringService = microserviceRegisterType.BaseType.GetGenericArguments().First();
                            if (_configuration.Services.All(x => x.Type != registeringService.FullName))
                            {
                                continue;
                            }
                        }
                        var mod = (Autofac.Module) Activator.CreateInstance(microserviceRegisterType, _configuration);
                        builder.RegisterModule(mod);
                    }

                    if (exportedTypes.Any(t => t.IsSubclassOf(typeof(ApiController))))
                    {
                        builder.RegisterApiControllers(assembly).InstancePerRequest();
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Configuration(IAppBuilder app)
        {

            var builder = new ContainerBuilder();

            builder.RegisterInstance<FoxyEcommConfiguration>(this._configuration).SingleInstance();

            builder.Register(
                    x =>
                        new RabbitMqCommandSender(_configuration.CommandQueue.ConnectionUri,
                            _configuration.CommandQueue.ExchangeName))
                .As<ICommandSender>();

            builder.Register(
                    x =>
                        new RabbitMqEventPublisher(_configuration.EventQueue.ConnectionUri,
                            _configuration.EventQueue.ExchangeName))
                .As<IEventPublisher>();

            builder.RegisterType<RabbitMqMessageSubscriber>()
                .Named<IMessageSubscriber>("CommandSubscriber");

            builder.RegisterType<RabbitMqMessageSubscriber>()
                .Named<IMessageSubscriber>("EventSubscriber");

            var mongoSetting = new MongoSetting
            {
                ConnectionString = _configuration.MongoEventStore.ConnectionString,
                CollectionName = _configuration.MongoEventStore.CollectionName,
                DatabaseName = _configuration.MongoEventStore.Database
            };
            builder.Register(x => new MongoDomainRepository(mongoSetting, x.Resolve<IEventPublisher>()))
                .As<IDomainRepository>();

            // Discovers the services.
            DiscoverServices(builder);

            // Register the API controllers within the current assembly.
            builder.RegisterApiControllers(this.GetType().Assembly);


            // Create the container by builder.
            var container = builder.Build();

            // Register the services.
            MicroServices.AddRange(container.Resolve<IEnumerable<IService>>());
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);

           
   

            HttpConfiguration config = new HttpConfiguration();
            //Handlers
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MessageHandlers.Add(new LocalizationMessageHandler());
            config.MessageHandlers.Add(new ApiResponseHandler());
            config.Filters.Add(new ValidateModelAttribute());
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           
            config.MapHttpAttributeRoutes();

            config.EnsureInitialized();

            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            
            //RegisterServiceToConsul();
        }

        public override void Start(object[] args)
        {
            // Validate the applicatoin configuration
            if (string.IsNullOrEmpty(_configuration?.ApplicationSetting?.Url))
            {
                throw new FoxyEcommConfigurationException("Url is not specified in the configuraiton.");
            }

            if (string.IsNullOrEmpty(_configuration?.CommandQueue?.ConnectionUri))
            {
                throw new FoxyEcommConfigurationException(
                    "ConnectionUri of the Command Queue is not specified in the configuraiton.");
            }

            if (string.IsNullOrEmpty(_configuration?.CommandQueue?.ExchangeName))
            {
                throw new FoxyEcommConfigurationException(
                    "ExchangeName of the Command Queue is not specified in the configuraiton.");
            }

            if (string.IsNullOrEmpty(_configuration?.EventQueue?.ConnectionUri))
            {
                throw new FoxyEcommConfigurationException(
                    "ConnectionUri of the Event Queue is not specified in the configuraiton.");
            }

            if (string.IsNullOrEmpty(_configuration?.EventQueue?.ExchangeName))
            {
                throw new FoxyEcommConfigurationException(
                    "ExchangeName of the Event Queue is not specified in the configuraiton.");
            }


            var url = _configuration.ApplicationSetting.Url;
            log.Info("Starting FoxyEcomm Service(s)");
            using (WebApp.Start<FoxyEcommService>(url: url))
            {
                MicroServices.ForEach(ms =>
                {
                    log.Info($"'{ms.GetType().Name}' Starting");
                    ms.Start(args);
                    log.Info($"'{ms.GetType().Name}' Started");
                });
                log.Info("FoxyEcomm Service(s) started with successfully.");
                Console.ReadLine();
            }
        }


        //private void RegisterServiceToConsul()
        //{
        //    using (var client = new ConsulClient())
        //    {
        //        var registration = new AgentServiceRegistration()
        //        {
        //            ID = "FoxyEcomm.Services.Proxy",
        //            Name = "FoxyEcomm.Services.Proxy",
        //            Address = "localhost",
        //            Port = 9023,
        //            Check = new AgentCheckRegistration()
        //            {
        //                HTTP = "http://localhost:9023/api/system/info",
        //                Interval = TimeSpan.FromSeconds(10)
        //            }
        //        };

        //        client.Agent.ServiceRegister(registration).Wait();
        //    }
        //}
    }
}
