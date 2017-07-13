using System;

namespace FoxyEcomm.Common.Exceptions
{
    public class FoxyEcommException : Exception
    {
        public FoxyEcommException() { }

        public FoxyEcommException(string message) : base(message)
        { }

        public FoxyEcommException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public FoxyEcommException(string format, params object[] args)
            : base(string.Format(format, args))
        { }
    }
}
