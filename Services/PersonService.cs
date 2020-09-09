using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using people_web_api.Models;

namespace people_web_api.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _people;

        public PersonService(IPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<Person>(settings.CollectionName);
        }

        public async Task<List<Person>> Get() =>
            await _people.Find(x => true).ToListAsync();

        public async Task<Person> Get(string id) =>
            await _people.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Person> Create(Person item)
        {
            await _people.InsertOneAsync(item);
            return item;
        }

        public async Task Update(string id, Person item)
        {
            var newPerson = new Person { Id = id };
            if (item.Name != null)
                newPerson.Name = item.Name;
            if (item.Age != default)
                newPerson.Age = item.Age;

            await _people.ReplaceOneAsync(x => x.Id == id, newPerson);
        }


        public async Task Remove(string id) =>
            await _people.DeleteOneAsync(x => x.Id == id);

        public async Task Remove(Person item) =>
            await _people.DeleteOneAsync(x => x.Id == item.Id);
    }
}