using System.Collections.Generic;
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

        public List<Person> Get() =>
            _people.Find(x => true).ToList();

        public Person Get(string id) =>
            _people.Find(x => x.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        public void Update(string id, Person person) =>
            _people.ReplaceOne(x => x.Id == id, person);

        public void Remove(string id) =>
            _people.DeleteOne(x => x.Id == id);

        public void Remove(Person person) =>
            _people.DeleteOne(x => x.Id == person.Id);
    }
}