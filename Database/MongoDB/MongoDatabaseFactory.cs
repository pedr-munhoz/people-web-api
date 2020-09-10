using MongoDB.Driver;

namespace people_web_api.Database.MongoDB
{
    public class MongoDatabaseFactory : INoSqlDatabaseFactory
    {
        public INoSqlDbConnection Create(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            return new MongoDbConnection(database, databaseName);
        }
    }
}