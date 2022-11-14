using Tenders.Core.Enums;
using Tenders.Data;

namespace Tenders.Core.Entities;

/// <summary>
/// Базовый класс пользователя
/// </summary>
public abstract class BaseUser : BaseEntity
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string EMail { get; set; }
    public string PhoneNumber { get; set; }
    public UserType UserType { get; set; }

    public BaseUser(string id, string login, string password, string eMail, string phoneNumber, UserType type)
    {
        Id = id;
        Login = login;
        Password = password;
        EMail = eMail;
        PhoneNumber = phoneNumber;
        UserType = type;
    }

    protected BaseUser(string login, string password, string eMail, string phoneNumber, UserType userType)
    {
        Login = login;
        Password = password;
        EMail = eMail;
        PhoneNumber = phoneNumber;
        UserType = userType;
    }
}