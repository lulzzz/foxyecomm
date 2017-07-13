using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace FoxyEcomm.Orm.SqlGenerator
{
    public class SqlPropertyMetadata
    {
        public SqlPropertyMetadata(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            var alias = PropertyInfo.GetCustomAttribute<ColumnAttribute>();
            if (!string.IsNullOrEmpty(alias?.Name))
            {
                Alias = alias.Name;
                ColumnName = Alias;
            }
            else
            {
                ColumnName = PropertyInfo.Name;
            }
        }

        public PropertyInfo PropertyInfo { get; }

        public string Alias { get; set; }

        public string ColumnName { get; set; }

        public string PropertyName => PropertyInfo.Name;
    }
}