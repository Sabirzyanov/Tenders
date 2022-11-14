using Tenders.Core.Entities;
using Tenders.Data;

namespace Tenders.Web.Services;

public class UserResourceService
{
    private readonly MongoProvider<BaseUser> _userProvider;

    public UserResourceService(MongoProvider<BaseUser> userProvider)
    {
        _userProvider = userProvider;
    }

    public async Task<IEnumerable<BaseUser?>> GetAllBuilders()
    {
        return (await _userProvider.GetAll()).ToList().Where(x => x.UserType == UserType.Builder);
    }
    
    public async Task<IEnumerable<BaseUser?>> GetAllArchitects()
    {
        return (await _userProvider.GetAll()).Where(x => x.UserType == UserType.Architect);
    }

    public async Task<IResult> Update(BaseUser user)
    {
        try
        {
            await _userProvider.Update(user);
            return Results.Ok("Successfully updated");
        }
        catch (Exception e)
        {
            return Results.Conflict("ERROR!!11!");
        }
    }

}