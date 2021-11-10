using MudBlazor;
using MudBlazor.Utilities;

namespace MudDemo.Client.Components.Index;

public partial class MudBlazorCard : MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();
}