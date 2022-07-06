using MudBlazor;
using MudDemo.Client.Auth;
using MudDemo.Client.Models;

namespace MudDemo.Client.Shared.Forms;

// For some reason, the Login page wasn't being able to find the form without this partial class
// I assume it's a bug related to it's namespoace.
public partial class LoginForm
{
    private readonly UserModel _user = new();
    private bool _isValid;
    private string[] _errors = Array.Empty<string>();
    private MudForm _form = null!;

    private async Task Login()
    {
        try
        {
            await ((SimpleAuthenticationStateProvider) Auth).AuthenticateUser(_user.DisplayName, _user.Email);
            Nav.NavigateTo("/", true);
        }
        catch
        {
            // ignored
        }
    }
}