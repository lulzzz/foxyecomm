using System;

namespace FoxyEcomm.Common.Exceptions
{
    public class FoxyEcommConfigurationException : FoxyEcommException
    {
        public FoxyEcommConfigurationException() { }

        public FoxyEcommConfigurationException(string message) : base(message)
        { }

        public FoxyEcommConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public FoxyEcommConfigurationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }
    }
}
