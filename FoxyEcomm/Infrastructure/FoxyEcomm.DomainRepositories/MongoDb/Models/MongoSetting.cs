namespace FoxyEcomm.DomainRepositories.MongoDb.Models
{
    public class MongoSetting
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
