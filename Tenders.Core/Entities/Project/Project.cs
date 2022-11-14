using Tenders.Core.Enums;

namespace Tenders.Core.Entities.Project;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string CustomerId { get; set; }
    public string ArchitectId { get; set; }
    public string BuilderId { get; set; }
    public IndustryType IndustryType { get; set; }

    public Project(string id, string name, string? description, string customerId, string architectId, string builderId, IndustryType industryType)
    {
        Id = id;
        Name = name;
        Description = description;
        CustomerId = customerId;
        ArchitectId = architectId;
        BuilderId = builderId;
        IndustryType = industryType;
    }

    public Project(string name, string? description, string customerId, string architectId, string builderId, IndustryType industryType)
    {
        Name = name;
        Description = description;
        CustomerId = customerId;
        ArchitectId = architectId;
        BuilderId = builderId;
        IndustryType = industryType;
    }
}