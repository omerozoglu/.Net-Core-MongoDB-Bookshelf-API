using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShelf.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}