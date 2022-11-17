using Tenders.Core.Entities.Project;
using Tenders.Core.Enums;
using Tenders.Data.DbModels;

namespace Tenders.Data.Resources;

public class ProjectRepository : BaseRepository<ProjectDbModel, Project>
{
    public ProjectRepository(MongoConnection<ProjectDbModel> mongoConnection) : base(mongoConnection)
    {
    }

    protected override Project CastModelToEntity(ProjectDbModel model)
    {
        return new Project(model.Id, model.Name, model.Description, model.CustomerId, model.ArchitectId, model.BuilderId, 
            (IndustryType) Enum.Parse(typeof(IndustryType), model.IndustryType));
    }

    protected override ProjectDbModel CastEntityToModel(Project entity)
    {
        return new ProjectDbModel(entity.Name, entity.Description, entity.CustomerId, entity.ArchitectId, entity.BuilderId, entity.IndustryType.ToString()) {Id = entity.Id};
    }
}