using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Common.Models
{
    public sealed class CommandConsumer : DisposableObject, ICommandConsumer
    {
        private readonly IEnumerable<ICommandHandler> commandHandlers;
        private readonly IMessageSubscriber subscriber;
        private bool disposed;

        public CommandConsumer(IMessageSubscriber subscriber, IEnumerable<ICommandHandler> commandHandlers)
        {
            this.subscriber = subscriber;
            this.commandHandlers = commandHandlers;
            subscriber.MessageReceived += async (sender, e) =>
              {
                  if (this.commandHandlers != null)
                  {
                      foreach (var handler in this.commandHandlers)
                      {
                          var handlerType = handler.GetType();
                          var messageType = e.Message.GetType();
                          var methodInfoQuery = from method in handlerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                let parameters = method.GetParameters()
                                                where method.Name == "HandleAsync" &&
                                                method.ReturnType == typeof(Task) &&
                                                parameters.Length == 1 &&
                                                parameters[0].ParameterType == messageType
                                                select method;
                          var methodInfo = methodInfoQuery.FirstOrDefault();
                          if (methodInfo != null)
                          {
                              await (Task)methodInfo.Invoke(handler, new[] { e.Message });
                          }
                      }
                  }
              };
        }

        public IEnumerable<ICommandHandler> CommandHandlers => commandHandlers;

        public IMessageSubscriber Subscriber => subscriber;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    this.subscriber.Dispose();
                    disposed = true;
                }
            }
        }
    }
}
