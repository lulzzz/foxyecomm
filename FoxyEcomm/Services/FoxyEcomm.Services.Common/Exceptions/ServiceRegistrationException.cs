using System;
using FoxyEcomm.Common.Exceptions;

namespace FoxyEcomm.Services.Common.Exceptions
{
    public class ServiceRegistrationException : FoxyEcommException
    {
        public ServiceRegistrationException()
        { }

        public ServiceRegistrationException(string message) : base(message)
        { }

        public ServiceRegistrationException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public ServiceRegistrationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }
    }
}
