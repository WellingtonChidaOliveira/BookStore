using BookStore.Shared.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace BookStore.Shared
{
    public class RentalBook : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; } = string.Empty;
        public Book Book { get; set; }
        //public int BookId { get; set; }
        //public string UserId { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public double TotalPrice { get; set; } = 0;
        public double Penalty { get; set; } = 0;
        public bool IsReturned { get; set; } = false;
    }
}
