using System.Text;

namespace FoxyEcomm.Orm.SqlGenerator
{
    public class SqlQuery
    {
        public SqlQuery()
        {
            SqlBuilder = new StringBuilder();
        }

        public SqlQuery(object param)
            : this()
        {
            Param = param;
        }

        public StringBuilder SqlBuilder { get; }

        public object Param { get; private set; }

        public string GetSql()
        {
            return SqlBuilder.ToString().TrimEnd();
        }

        public void SetParam(object param)
        {
            Param = param;
        }
    }
}