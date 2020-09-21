namespace people_web_api.Database
{
    /// <summary>
    /// A interface for a NoSQL database connection instance.
    /// </summary>
    public interface INoSqlDbConnection
    {
        /// <summary>
        /// The name of the database connection.
        /// </summary>
        /// <value></value>
        string Name { get; }

        /// <summary>
        /// Selects a collection from the database connection based on the given <paramref name="collectionName"/>.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <typeparam name="T">The type of the items on the collection.</typeparam>
        /// <returns>Interface for a NoSQL collection.</returns>
        INoSqlCollection<T> GetCollection<T>(string collectionName);

        /// <summary>
        /// Selects a collection from the database connection based on a default value.
        /// </summary>
        /// <typeparam name="T">The type of the items on the collection.</typeparam>
        /// <returns>Interface for a NoSQL collection.</returns>
        INoSqlCollection<T> GetCollection<T>();
    }
}