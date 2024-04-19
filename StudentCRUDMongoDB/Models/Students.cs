using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentCRUDMongoDB.Models
{
    public class Students
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("firstName")]
        public string? firstName { get; set; }

        [BsonElement("lastName")]
        public string? lastName { get; set; }

        [BsonElement("address")]
        public string? address { get; set; }

        [BsonElement("email")]
        public string? email { get; set; }

        [BsonElement("dob")]
        public string? dob { get; set; }

        [BsonElement("gender")]
        public string? gender { get; set; }
    }
}
