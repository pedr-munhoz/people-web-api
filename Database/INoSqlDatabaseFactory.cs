namespace people_web_api.Database
{
    public interface INoSqlDatabaseFactory
    {
        INoSqlDbConnection Create(string connectionString);
    }
}