using BookStore.Shared.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BookStore.Shared
{
    public class Customer : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; } = string.Empty;

        [BsonElement("email")]  
        public string Email { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("phone")]
        public List<Phone> Phone { get; set; } = new List<Phone>();

        [BsonElement("address")]
        public List<Address> Address { get; set; } = new List<Address>();

        [BsonElement("photo")]
        public byte[] Photo { get; set; } = new byte[0];

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
