using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShelf.Models
{
    public class BookShelfm
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string BookID { get; set; }
    }
}