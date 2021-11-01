using Microsoft.AspNetCore.Components;
using MudDemo.Client.Models;

namespace MudDemo.Client.Components.Shared;

public partial class UserMenu
{
    [Parameter] public string Class { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; }
}