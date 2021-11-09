using System.Text.Json.Serialization;
using MudDemo.Client.Models.Charts.Annotations;
using MudDemo.Client.Models.Charts.Chart;
using MudDemo.Client.Models.Charts.DataLabels;
using MudDemo.Client.Models.Charts.Fill;
using MudDemo.Client.Models.Charts.ForecastDataPoints;
using MudDemo.Client.Models.Charts.Grid;
using MudDemo.Client.Models.Charts.Legend;
using MudDemo.Client.Models.Charts.NoData;
using MudDemo.Client.Models.Charts.PlotOptions;
using MudDemo.Client.Models.Charts.Responsive;
using MudDemo.Client.Models.Charts.Series;
using MudDemo.Client.Models.Charts.States;
using MudDemo.Client.Models.Charts.Stroke;
using MudDemo.Client.Models.Charts.Subtitle;
using MudDemo.Client.Models.Charts.Theme;
using MudDemo.Client.Models.Charts.Title;
using MudDemo.Client.Models.Charts.Tooltip;
using MudDemo.Client.Models.Charts.XAxis;
using MudDemo.Client.Models.Charts.YAxis;

namespace MudDemo.Client.Models.Charts;

public class ChartOptionsModel<TSeries, TXAxis>
{
    [JsonPropertyName("annotations")] public AnnotationsModel Annotations { get; set; } = new();
    [JsonPropertyName("chart")] public ChartModel Chart { get; set; } = new();
    //
    [JsonPropertyName("colors")]
    public List<string> Colors { get; set; } = new() {"var(--mud-palette-primary)", "var(--mud-palette-secondary)"};
    
    [JsonPropertyName("dataLabels")] public DataLabelsModel DataLabels { get; set; } = new();
    [JsonPropertyName("fill")] public FillModel Fill { get; set; } = new();
    
    [JsonPropertyName("forecastDataPoints")]
    public ForecastDataPointsModel ForecastDataPoints { get; set; } = new();

    // [JsonPropertyName("grid")] public GridModel Grid { get; set; } = new(); // TODO: Yaxis issue...
    [JsonPropertyName("labels")] public List<string> Labels { get; set; } = new();
    [JsonPropertyName("legend")] public LegendModel Legend { get; set; } = new();
    [JsonPropertyName("markers")] public LegendModel.MarkersModel Markers { get; set; } = new();
    [JsonPropertyName("noData")] public NoDataModel NoData { get; set; } = new();
    [JsonPropertyName("plotOptions")] public PlotOptionsModel PlotOptions { get; set; } = new();
    [JsonPropertyName("responsive")] public List<ResponsiveModel> Responsive { get; set; } = new();
    [JsonPropertyName("series")] public List<TSeries> Series { get; set; } = new();
    [JsonPropertyName("states")] public StatesModel States { get; set; } = new();
    [JsonPropertyName("stroke")] public StrokeModel Stroke { get; set; } = new();
    [JsonPropertyName("subtitle")] public SubtitleModel Subtitle { get; set; } = new();
    [JsonPropertyName("theme")] public ThemeModel Theme { get; set; } = new();
    [JsonPropertyName("title")] public TitleModel Title { get; set; } = new();
    [JsonPropertyName("tooltip")] public TooltipModel Tooltip { get; set; } = new();
    [JsonPropertyName("xaxis")] public XAxisModel<TXAxis> XAxis { get; set; } = new();
    [JsonPropertyName("yaxis")] public YAxisModel YAxis { get; set; } = new();
}