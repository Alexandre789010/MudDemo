using Microsoft.AspNetCore.Components;
using MudBlazor;
using Toolbelt.Blazor.HotKeys;

namespace MudDemo.Client.Components.Shared;

public partial class CommandPalette
{
    private HotKeysContext? _hotKeysContext;
    private string _search;
    [Inject] private HotKeys _hotKeys { get; set; }

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

    protected override void OnInitialized()
    {
        _hotKeysContext = _hotKeys.CreateContext()
            .Add(ModKeys.None, Keys.ESC, () => MudDialog.Close(), "Close command palette.");
    }

    public void Dispose()
    {
        _hotKeysContext?.Dispose();
    }
}