using Tenders.Core.Enums;

namespace Tenders.Core.Entities.Document;

public abstract class BaseDocument : BaseEntity
{
    public string Name { get; set; }
    public string FilenameExt { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsRequired { get; set; }
    public string OwnerId { get; set; }
    public string FileId { get; set; }
    public string ProjectId { get; set; }
    public DocumentType DocumentType { get; set; }
}