using Tenders.Data.DbModels.BaseModel;

namespace Tenders.Data.DbModels;

public class DocumentDbModel : BaseDbModel
{
    public string? Name { get; set; }
    public string? FilenameExt { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsRequired { get; set; }
    public string? OwnerId { get; set; }
    public string? FileId { get; set; }
    public string? ProjectId { get; set; }
    public string? DocumentType { get; set; }
    public string? SpecificationType { get; set; }

    public DocumentDbModel(string? name, bool isAccepted, bool isRequired, string? ownerId, 
        string? fileId, string? projectId, string? documentType, string? specificationType, string filenameExt)
    {
        Name = name;
        IsAccepted = isAccepted;
        IsRequired = isRequired;
        OwnerId = ownerId;
        FileId = fileId;
        ProjectId = projectId;
        DocumentType = documentType;
        SpecificationType = specificationType;
        FilenameExt = filenameExt;
    }
}