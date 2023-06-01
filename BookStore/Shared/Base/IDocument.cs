using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Shared.Base
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string id { get; set; }
        
    }
}
