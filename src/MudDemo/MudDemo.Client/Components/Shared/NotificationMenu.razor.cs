using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Utilities;
using MudDemo.Client.Models.Notification;
using MudDemo.Client.Services;

namespace MudDemo.Client.Components.Shared;

public partial class NotificationMenu : MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();
    
    [Parameter] public IEnumerable<NotificationModel>? Notifications { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClickViewAll { get; set; }
}