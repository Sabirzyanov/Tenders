using Tenders.Core.Entities;
using Tenders.Core.Entities.Project;
using Tenders.Core.Enums;
using Tenders.Data;

namespace Tenders.Web.Services;

public class ProjectResourceService
{
    private readonly MongoProvider<Project> _projectProvider;

    public ProjectResourceService(MongoProvider<Project> userProvider)
    {
        _projectProvider = userProvider;
    }

    public async Task<IResult> Save(Project project)
    {
        await _projectProvider.Save(project);
        return Results.Ok();
    }

    public async Task<Project> GetProjectById(string id)
    {
        return await _projectProvider.GetEntityById(id);
    }

    public async Task<IEnumerable<Project>> GetProjectsByIndustry(IndustryType industryType)
    {
        return (await _projectProvider.GetAll()).Where(x => x.IndustryType == industryType);
    }

    public async Task<IEnumerable<Project>> GetAllProjects()
    {
        return await _projectProvider.GetAll(); 
    }
}