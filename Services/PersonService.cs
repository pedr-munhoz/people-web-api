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

        public Person Create(Person item)
        {
            _people.InsertOne(item);
            return item;
        }

        public void Update(string id, Person item)
        {
            var newPerson = new Person { Id = id };
            if (item.Name != null)
                newPerson.Name = item.Name;
            if (item.Age != default)
                newPerson.Age = item.Age;

            _people.ReplaceOne(x => x.Id == id, newPerson);
        }


        public void Remove(string id) =>
            _people.DeleteOne(x => x.Id == id);

        public void Remove(Person item) =>
            _people.DeleteOne(x => x.Id == item.Id);
    }
}