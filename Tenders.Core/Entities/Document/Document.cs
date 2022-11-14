namespace Tenders.Core.Entities.Document;

public class Document : BaseEntity
{
    public string Name { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsRequired { get; set; }
    public int OwnerId { get; set; }
    public int FileId { get; set; }
    public int ProjectId { get; set; }

    public Document(string name, bool isAccepted, bool isRequired, int ownerId, int fileId, int projectId)
    {
        Name = name;
        IsAccepted = isAccepted;
        IsRequired = isRequired;
        OwnerId = ownerId;
        FileId = fileId;
        ProjectId = projectId;
    }
}