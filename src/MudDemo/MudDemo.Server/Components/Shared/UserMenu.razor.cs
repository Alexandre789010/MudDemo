using Microsoft.AspNetCore.Components;
using MudDemo.Server.Models;

namespace MudDemo.Server.Components.Shared;

public partial class UserMenu
{
    [Parameter] public string Class { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; }
}