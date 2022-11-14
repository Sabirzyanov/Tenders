using MongoDB.Bson.Serialization.Attributes;
using Tenders.Core.Enums;
using Tenders.Data.DbModels.BaseModel;

namespace Tenders.Data.DbModels;

public class ProjectDbModel : BaseDbModel
{
    public string Name { get; set; }
    [BsonIgnoreIfDefault]
    public string? Description { get; set; }
    public string CustomerId { get; set; }
    public string ArchitectId { get; set; }
    public string BuilderId { get; set; }
    public string IndustryType { get; set; }

    public ProjectDbModel(string name, string? description, string customerId, string architectId, string builderId, string industryType)
    {
        Name = name;
        Description = description;
        CustomerId = customerId;
        ArchitectId = architectId;
        BuilderId = builderId;
        IndustryType = industryType;
    }
}