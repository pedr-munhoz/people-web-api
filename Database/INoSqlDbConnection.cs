namespace people_web_api.Database
{
    public interface INoSqlDbConnection
    {
        string Name { get; }

        INoSqlCollection<T> GetCollection<T>(string collectionName);

        INoSqlCollection<T> GetCollection<T>();
    }
}