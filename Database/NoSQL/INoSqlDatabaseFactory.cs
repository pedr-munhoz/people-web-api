namespace people_web_api.Database
{
    /// <summary>
    /// Base interface for a NoSQL database factory.
    /// </summary>
    public interface INoSqlDatabaseFactory
    {
        /// <summary>
        /// Standard method for creating a database.
        /// </summary>
        /// <param name="connectionString">The connectionString used to connect to the client.</param>
        /// <param name="databaseName">The name of the database to connect to.</param>
        /// <returns>A interface for a NoSQL database connection instance.</returns>
        INoSqlDbConnection Create(string connectionString, string databaseName);
    }
}