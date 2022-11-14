using Tenders.Data;

namespace Tenders.Core.Entities;


public class Builder : BaseUser
{
    public string? Name { get; set; }
    public string? PSRN { get; set; } // ОГРН
    public string? TIN { get; set; } // ИНН
    public string? TRRC { get; set; } // КПП
    public string? Manager { get; set; }
    public string? Address { get; set; }

    public Builder(string id, string login, string password, string eMail, string phoneNumber, string name, string psrn, 
        string tin, string trrc, string manager, string address, UserType type) 
        : base(id, login, password, eMail, phoneNumber, type)
    {
        Name = name;
        PSRN = psrn;
        TIN = tin;
        TRRC = trrc;
        Manager = manager;
        Address = address;
    }

    public Builder(string login, string password, string eMail, string phoneNumber, UserType type) : 
        base(login, password, eMail, phoneNumber, type)
    {
    }
}