using System.Security.Cryptography;
using System.Text;
using ImagesViewerProject.Services.Interfaces;
using Tenders.Core.Entities;
using Tenders.Data;

namespace Tenders.Web.Services;

public class AuthorizationService
{
    private readonly HMACSHA256 _encryptor;
    private readonly MongoProvider<BaseUser> _mongoProvider;
    private readonly ILocalStorageService _localStorageService;

    public BaseUser? CurrentUser { get; private set; }

    public AuthorizationService(IConfiguration configuration, MongoProvider<BaseUser> mongoProvider, ILocalStorageService localStorageService)
    {
        _encryptor = new HMACSHA256(
            Encoding.UTF8.GetBytes(configuration["Encryption:Key"] ?? String.Empty));
        _mongoProvider = mongoProvider;
        _localStorageService = localStorageService;
    }

    public async Task<IResult> Authorize(string email, string password)
    {
        BaseUser? potentialUser = (await _mongoProvider.GetAll()).FirstOrDefault(x => x.EMail == email);

        if (potentialUser is null)
            return Results.Conflict("Member was not  registered");

        if (potentialUser.Password != ComputeHashPassword(password))
            return Results.Conflict("Passwords dont match");

        CurrentUser = potentialUser;
        await SetUser(potentialUser.Login);
        return Results.Ok("Successfully authorized");
    }

    public async Task<IResult> Register(BaseUser user)
    {
        if ((await _mongoProvider.GetAll()).FirstOrDefault(x => x.EMail == user.EMail) is not null)
            return Results.BadRequest("This email has been registered!");

        if (user is null)
            return Results.Conflict("ERROR!!");

        await _mongoProvider.Save(user);
        return Results.Ok();
    }

    public string ComputeHashPassword(string password)
    {
        if (password is null)
            return "";
        
        return Encoding.UTF8.GetString(_encryptor.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public async Task<IResult> Logout()
    {
        CurrentUser = null;
        await _localStorageService.RemoveAsync("key");
        return Results.Ok("Successfully logout");
    }

    private async Task<IResult> SetUser(string login)
    {
        await _localStorageService.SetStringAsync("key", login);
        return Results.Ok("Successfully login");
    }
    
    
    public async Task CanGetUserByLogin()
    {
        string potentialUserLogin = await _localStorageService.GetStringAsync("key");
        
        if (string.IsNullOrEmpty(potentialUserLogin))
            return;
        
        CurrentUser = (await _mongoProvider.GetAll()).FirstOrDefault(x => x.Login == potentialUserLogin);
    }

}