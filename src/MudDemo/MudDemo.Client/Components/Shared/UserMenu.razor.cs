using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudDemo.Client.Auth;
using MudDemo.Client.Models;

namespace MudDemo.Client.Components.Shared;

public partial class UserMenu
{
    [Inject] private AuthenticationStateProvider Auth { get; set; }
    [Inject] private NavigationManager Nav { get; set; }
    [Parameter] public string Class { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; }

    private async Task Logout()
    {
        await ((SimpleAuthenticationStateProvider) Auth).Logout();
        Nav.NavigateTo("/", true);
    }
}