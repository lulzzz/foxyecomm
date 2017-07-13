using System;

namespace FoxyEcomm.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static Guid ToGuid(this string data)
        {
            return new Guid(data);
        }

        public static T TryToCast<T>(this object value)
        {
            if (value == null)
            {
                return default(T);
            }
            if (value is T)
            {
                return (T)value;
            }
            try
            {

                if (typeof(T).IsEnum)
                {
                    return (T)Enum.Parse(typeof(T), value.ToString());
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }

        }
    }
}
