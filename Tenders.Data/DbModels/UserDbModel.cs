using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tenders.Data.DbModels.BaseModel;

namespace Tenders.Data.DbModels;


public class UserDbModel : BaseDbModel
{
    [BsonIgnoreIfDefault]
    public string Login { get; set; }
    
    [BsonIgnoreIfDefault]
    public string Password { get; set; }
    [BsonIgnoreIfDefault]
    public string EMail { get; set; }
    
    [BsonIgnoreIfDefault]
    public string PhoneNumber { get; set; }
    
    [BsonIgnoreIfDefault]
    public string UserRole { get; set; }
    [BsonIgnoreIfDefault]
    public string? IndustryType { get; set; }
    [BsonIgnoreIfDefault]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    public string? PSRN { get; set; }
    [BsonIgnoreIfDefault]
    public string? TIN{ get; set; }
    [BsonIgnoreIfDefault]
    public string? TRRC { get; set; }
    [BsonIgnoreIfDefault]
    public string? Address { get; set; }
    [BsonIgnoreIfDefault]
    public string? Director { get; set; }
    [BsonIgnoreIfDefault]
    public string? ProjectManager { get; set; }

    public UserDbModel(string id, string login, string password, string eMail, string phoneNumber, string userRole)
    {
        Id = id;
        Login = login;
        Password = password;
        EMail = eMail;
        PhoneNumber = phoneNumber;
        UserRole = userRole;
    }
}