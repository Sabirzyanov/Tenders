using Tenders.Core.Entities.Document;
using Tenders.Core.Entities.Documents;
using Tenders.Core.Enums;
using Tenders.Data.DbModels;

namespace Tenders.Data.Resources;

public class DocumentRepository : BaseRepository<DocumentDbModel, BaseDocument>
{
    public DocumentRepository(MongoConnection<DocumentDbModel> mongoConnection) : base(mongoConnection)
    {
    }

    protected override BaseDocument CastModelToEntity(DocumentDbModel model)
    {
        return model.DocumentType switch
        {
            "GasSupplyDocument" => new GasSupplyDocument()
            {
                Id = model.Id,
                Name = model.Name, IsAccepted = model.IsAccepted, IsRequired = model.IsRequired,
                OwnerId = model.OwnerId, FileId = model.FileId, ProjectId = model.ProjectId, FilenameExt = model.FilenameExt,
                Type = (GasSupplyDocumentTypes)Enum.Parse(typeof(GasSupplyDocumentTypes), model.SpecificationType),
                DocumentType = DocumentType.GasSupplyDocument
            },
            "WaterSupplyDocument" => new WaterSupplyDocument()
            {
                Id = model.Id,
                Name = model.Name, IsAccepted = model.IsAccepted, IsRequired = model.IsRequired,
                OwnerId = model.OwnerId, FileId = model.FileId, ProjectId = model.ProjectId, FilenameExt = model.FilenameExt,
                Type = (WaterSupplyDocumentType)Enum.Parse(typeof(WaterSupplyDocumentType), model.SpecificationType),
                DocumentType = DocumentType.WaterSupplyDocument
            },
        };
    }

    protected override DocumentDbModel CastEntityToModel(BaseDocument entity)
    {
        return entity.DocumentType switch
        {
            DocumentType.GasSupplyDocument => new DocumentDbModel(entity.Name, entity.IsAccepted, entity.IsRequired,
                entity.OwnerId, entity.FileId, entity.ProjectId, "GasSupplyDocument",
                (entity as GasSupplyDocument).Type.ToString(), entity.FilenameExt) {Id = entity.Id},
            DocumentType.WaterSupplyDocument => new DocumentDbModel(entity.Name, entity.IsAccepted, entity.IsRequired,
                entity.OwnerId, entity.FileId, entity.ProjectId, "WaterSupplyDocument",
                (entity as WaterSupplyDocument).Type.ToString(), entity.FilenameExt) {Id = entity.Id}
        };
    }
}