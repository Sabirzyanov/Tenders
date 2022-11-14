using Tenders.Core.Enums;
using Tenders.Data;

namespace Tenders.Core.Entities;

public class Customer : BaseUser
{
    public IndustryType? IndustryType { get; set; }
    public string? FullName { get; set; }
    public Customer(string id, string login, string password, string eMail, string phoneNumber, UserType type, 
        IndustryType industryType, string fullName) : 
        base(id, login, password, eMail, phoneNumber, type)
    {
        IndustryType = industryType;
        FullName = fullName;
    }

    public Customer(string login, string password, string eMail, string phoneNumber, UserType type) : base(login, password, eMail, phoneNumber, type)
    {
    }
}