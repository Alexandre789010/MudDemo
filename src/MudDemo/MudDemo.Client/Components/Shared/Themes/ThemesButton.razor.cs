using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MudDemo.Client.Components.Shared.Themes;

public partial class ThemesButton
{
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
}