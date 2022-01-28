using Microsoft.AspNetCore.Components;
using MudDemo.Client.Models;
using MudDemo.Client.Models.Notification;
using MudDemo.Client.Services;

namespace MudDemo.Client.Components.Shared;

public partial class NavMenu
{
    private IEnumerable<NotificationModel> _activeNotifications;

    [Inject] private INotificationsService NotificationsService { get; set; }

    [EditorRequired] [Parameter] public ThemeManagerModel ThemeManager { get; set; } = default!;
    [EditorRequired] [Parameter] public bool SideMenuDrawerOpen { get; set; }
    [EditorRequired] [Parameter] public EventCallback ToggleSideMenuDrawer { get; set; }
    [EditorRequired] [Parameter] public EventCallback OpenCommandPalette { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; } = default!;
 

    protected override async Task OnInitializedAsync()
    {
        _activeNotifications = await NotificationsService.GetActiveNotifications();
    }
}