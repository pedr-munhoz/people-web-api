using MongoDB.Driver;

namespace people_web_api.Database.NoSQL.MongoDB
{
    public class MongoDbConnection : INoSqlDbConnection
    {
        public string Name { get; }
        private readonly IMongoDatabase _database;

        public MongoDbConnection(IMongoDatabase database, string name = "")
        {
            _database = database;
            Name = name;
        }

        public INoSqlCollection<T> GetCollection<T>(string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return new MongoCollection<T>(collection);
        }

        public INoSqlCollection<T> GetCollection<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}