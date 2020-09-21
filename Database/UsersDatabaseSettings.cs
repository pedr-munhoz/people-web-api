using people_web_api.Database.SQL;

namespace people_web_api.Database
{
    public class UsersDatabaseSettings : ISqlDbSettings
    {
        public string ConnectionString { get; set; }
    }
}