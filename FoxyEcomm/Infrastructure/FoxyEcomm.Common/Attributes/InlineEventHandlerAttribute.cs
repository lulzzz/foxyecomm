using System;

namespace FoxyEcomm.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class InlineEventHandlerAttribute : Attribute
    {

    }
}
