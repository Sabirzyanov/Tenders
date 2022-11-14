using Tenders.Core.Entities;
using Tenders.Core.Enums;
using Tenders.Data.DbModels;

namespace Tenders.Data.Resources;

public class UserRepository : BaseRepository<UserDbModel, BaseUser>
{
    public UserRepository(MongoConnection<UserDbModel> mongoConnection) : base(mongoConnection)
    {
    }

    protected override UserDbModel CastEntityToModel(BaseUser user)
    {
        UserDbModel dbModel = user.UserType switch
        {
            UserType.Architect => new UserDbModel(user.Id, user.Login, user.Password, user.EMail, user.PhoneNumber,
                user.UserType.ToString())
            {
                Name = (user as Architect).OrganizationName,
                PSRN = (user as Architect).PSRN, TIN = (user as Architect).TIN, TRRC = (user as Architect).TRRC,
                Address = (user as Architect).Address, Director = (user as Architect).Director,
                ProjectManager = (user as Architect).ProjectManager
            },

            UserType.Builder => new UserDbModel(user.Id, user.Login, user.Password, user.EMail, user.PhoneNumber,
                user.UserType.ToString())
            {
                Name = (user as Builder).Name,
                PSRN = (user as Builder).PSRN, TIN = (user as Builder).TIN, TRRC = (user as Builder).TRRC,
                Address = (user as Builder).Address, Director = (user as Builder).Manager,
            },

            UserType.Customer => new UserDbModel(user.Id, user.Login, user.Password, user.EMail, user.PhoneNumber,
                user.UserType.ToString())
            {
                IndustryType = (user as Customer).IndustryType.ToString(),
                Name = (user as Customer).FullName
            }
        };

        return dbModel;
    }

    protected override BaseUser CastModelToEntity(UserDbModel model)
    {
        try
        {
            BaseUser user = model.UserRole switch
            {
                "Architect" => new Architect(model.Id, model.Login, model.Password, model.EMail, model.PhoneNumber,
                    model.Name, model.PSRN, model.TIN, model.TRRC, model.Address, model.Director, model.ProjectManager,
                    UserType.Architect),
                "Builder" => new Builder(model.Id, model.Login, model.Password, model.EMail, model.PhoneNumber,
                    model.Name, model.PSRN, model.TIN, model.TRRC, model.ProjectManager, model.Address,
                    UserType.Builder),
                "Customer" => new Customer(model.Id, model.Login, model.Password, model.EMail, model.PhoneNumber,
                    UserType.Customer, (IndustryType)Enum.Parse(typeof(IndustryType), model.IndustryType), model.Name)
            };

            return user;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}