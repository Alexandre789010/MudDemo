using Microsoft.AspNetCore.Components;
using MudDemo.Client.Models;

namespace MudDemo.Client.Components.Shared;

public partial class NavMenu
{
    [EditorRequired] [Parameter] public ThemeManagerModel ThemeManager { get; set; }
    [EditorRequired] [Parameter] public bool CanMiniSideMenuDrawer { get; set; }
    [EditorRequired] [Parameter] public EventCallback ToggleSideMenuDrawer { get; set; }
    [EditorRequired] [Parameter] public EventCallback OpenCommandPalette { get; set; }

    [EditorRequired] [Parameter] public UserModel User { get; set; }

}