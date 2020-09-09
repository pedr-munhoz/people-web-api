using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace people_web_api.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}