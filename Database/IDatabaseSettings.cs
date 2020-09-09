namespace people_web_api.Database
{
    /// <summary>
    /// Interface containing the necessary attributes for a runtime database setup.
    /// </summary>
    public interface IDatabaseSettings
    {
        /// <summary>
        /// Connection string to determine the client.
        /// </summary>
        /// <value></value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Name of the database inside the client.
        /// </summary>
        /// <value></value>
        string DatabaseName { get; set; }

        /// <summary>
        /// Name of the specific collection inside the database.
        /// </summary>
        /// <value></value>
        string CollectionName { get; set; }
    }
}