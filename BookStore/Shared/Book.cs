using BookStore.Shared.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace BookStore.Shared
{
    public class Book : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;
        [BsonElement("author")]
        public string AuthorName { get; set; } = string.Empty;
        [BsonElement("publisher")]
        public string Publisher { get; set; } = string.Empty;
        //public string ISBN { get; set; } Unique numeric book identifier
        [BsonElement("price")]
        public string Price { get; set; } = string.Empty;
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
        [BsonElement("photo")]
        public byte[] Photo { get; set; } = new byte[0];
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
