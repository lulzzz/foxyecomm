using FoxyEcomm.Orm.Models;

namespace FoxyEcomm.Orm.SqlGenerator
{
    public class SqlGeneratorConfig
    {
        public ESqlConnector SqlConnector { get; set; }

        public bool UseQuotationMarks { get; set; }
    }
}