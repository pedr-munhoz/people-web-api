using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using people_web_api.Models;

namespace people_web_api.Services
{
    /// <summary>
    /// Service class for interacting with the data contained on the MongoDB.
    /// </summary>
    public class PersonService
    {
        /// <summary>
        /// Collection containing the necessary data.
        /// </summary>
        private readonly IMongoCollection<Person> _people;

        /// <summary>
        /// Contstructor: recieves a <paramref name="settings"/> object used 
        /// for gainning access to the client database and appropriate collection.
        /// </summary>
        /// <param name="settings">Object cointaing the fields necessary for accessing the DB.</param>
        public PersonService(IPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<Person>(settings.CollectionName);
        }

        /// <summary>
        /// Method to retrieve the people collection from the database.
        /// </summary>
        /// <returns>List of all the people.</returns>
        public async Task<List<Person>> Get() =>
            await _people.Find(x => true).ToListAsync();

        /// <summary>
        /// Method to retrieve a specific person based on its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identifying filed of the person.</param>
        /// <returns>
        /// The person associated with the specified <paramref name="id"/>, or <c>null</c> if no person is associated.
        /// </returns>
        public async Task<Person> Get(string id) =>
            await _people.Find(x => x.Id == id).FirstOrDefaultAsync();

        /// <summary>
        /// Method to create a new person.
        /// </summary>
        /// <param name="item">Set of attributes to create the person with.</param>
        /// <returns>The created person with newly assigned id.</returns>
        public async Task<Person> Create(Person item)
        {
            await _people.InsertOneAsync(item);
            return item;
        }

        /// <summary>
        /// Method used to update one or more attributes of a existing person.
        /// </summary>
        /// <param name="id">Identifying filed of the person.</param>
        /// <param name="item">Set of attributes to updatethe person with.</param>
        /// <returns>void</returns>
        public async Task Update(string id, Person item)
        {
            var newPerson = new Person { Id = id };
            if (item.Name != null)
                newPerson.Name = item.Name;
            if (item.Age != default)
                newPerson.Age = item.Age;

            await _people.ReplaceOneAsync(x => x.Id == id, newPerson);
        }

        /// <summary>
        /// Method used to delete a person based on its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identifying filed of the person.</param>
        /// <returns>void</returns>
        public async Task Remove(string id) =>
            await _people.DeleteOneAsync(x => x.Id == id);

        /// <summary>
        /// Overload function to remove a person while recieving the whole model. 
        /// Person is removed based on the id attributes of the <paramref name="item"/> object.
        /// </summary>
        /// <param name="item">Penson to remove.</param>
        /// <returns>void</returns>
        public async Task Remove(Person item) =>
            await _people.DeleteOneAsync(x => x.Id == item.Id);
    }
}