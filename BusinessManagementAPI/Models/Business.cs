using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessManagementAPI.Models
{
    public class Business
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string BusinessId { get; set; } = string.Empty;

        public string BusinessName { get; set; } = string.Empty;

        public string CreatorId {  get; set; } = string.Empty;

        public string CreatorName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
