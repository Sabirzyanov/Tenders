using Tenders.Data;

namespace Tenders.Core.Entities;

public class Architect : BaseUser
{
    public string? OrganizationName { get; set; }
    public string? PSRN { get; set; } // ОГРН
    public string? TIN { get; set; } // ИНН
    public string? TRRC { get; set; } // КПП
    public string? Address { get; set; }
    public string? Director { get; set; }
    public string? ProjectManager { get; set; }

    public Architect(string id, string login, string password, string eMail, string phoneNumber, string organizationName, 
        string psrn, string tin, string trrc, string address, string director, string projectManager, UserType type) : 
        base(id, login, password, eMail, phoneNumber, type)
    {
        OrganizationName = organizationName;
        PSRN = psrn;
        TIN = tin;
        TRRC = trrc;
        Address = address;
        Director = director;
        ProjectManager = projectManager;
    }

    public Architect(string login, string password, string eMail, string phoneNumber, UserType type) : base(login, password, eMail, phoneNumber, type)
    {
    }
}