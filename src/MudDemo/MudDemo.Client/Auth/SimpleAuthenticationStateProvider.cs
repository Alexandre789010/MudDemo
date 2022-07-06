using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudDemo.Client.Models;

namespace MudDemo.Client.Auth;

public class SimpleAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymousUser = new(new ClaimsPrincipal(new ClaimsIdentity()));

    public SimpleAuthenticationStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userData = await _localStorage.GetItemAsync<UserModel>("userData");

        return userData is null ? _anonymousUser : BuildAuthenticationState(userData);
    }

    public async Task AuthenticateUser(string user, string email)
    {
        var userModel = new UserModel
        {
            DisplayName = user,
            Email = email
        };
        
        await _localStorage.SetItemAsync("userData", userModel);

        var state = BuildAuthenticationState(userModel);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }

    private static AuthenticationState BuildAuthenticationState(UserModel user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.DisplayName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        var identity = new ClaimsIdentity(claims, "Admin");
        var userPrincipal = new ClaimsPrincipal(identity);

        return new AuthenticationState(userPrincipal);
    }

    public async Task Logout() => await _localStorage.RemoveItemAsync("userData");
}