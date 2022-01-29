using System.Text.Json.Serialization;

namespace MudDemo.Server.Models.Charts.Title;

public class TitleModel
{
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;
    [JsonPropertyName("align")] public string Align { get; set; } = "left";
    [JsonPropertyName("margin")] public int Margin { get; set; } = 10;
    [JsonPropertyName("offsetX")] public int OffsetX { get; set; } = 0;
    [JsonPropertyName("offsetY")] public int OffsetY { get; set; } = 0;
    [JsonPropertyName("floating")] public bool Floating { get; set; } = false;
    [JsonPropertyName("style")] public StyleModel Style { get; set; } = new();

    public class StyleModel
    {
        [JsonPropertyName("fontSize")] public string FontSize { get; set; } = "14px";
        [JsonPropertyName("fontWeight")] public string FontWeight { get; set; } = "bold";
        [JsonPropertyName("fontFamily")] public string FontFamily { get; set; } = string.Empty;
        [JsonPropertyName("color")] public string Color { get; set; } = "#263238";
    }
}