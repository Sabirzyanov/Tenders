using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tenders.Data.DbModels.BaseModel;

public class BaseDbModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}