using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;
using MudDemo.Client.Models.Charts;

namespace MudDemo.Client.Components.Charts;

public partial class ApexChart<TSeries, TCategory> : MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();

    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;
    [EditorRequired] [Parameter] public string ChartId { get; set; } = string.Empty;
    [EditorRequired] [Parameter] public ChartOptionsModel<TSeries, TCategory>? ChartOptions { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ChartOptions == null)
            return;

        if (firstRender) await JsRuntime.InvokeVoidAsync("apexChart", ChartId, ChartOptions);
    }
}