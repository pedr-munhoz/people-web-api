namespace people_web_api.Database
{
    public class PeopleDatabaseSettings : INoSqlDbSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}