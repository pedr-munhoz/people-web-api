using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace people_web_api.Models
{
    /// <summary>
    /// Gereric representation of a person, model compatible with MongoDB.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Object identifier, generated by MongoDB.
        /// </summary>
        /// <value></value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Required field containing the name of the person.
        /// </summary>
        /// <value></value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Elective field containing the age of the person.
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
    }
}