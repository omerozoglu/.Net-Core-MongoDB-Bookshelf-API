using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShelf.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Translator { get; set; }
        public int Edition { get; set; }
        public string EditionDate { get; set; }
        public int PageNumber { get; set; }

    }
}

