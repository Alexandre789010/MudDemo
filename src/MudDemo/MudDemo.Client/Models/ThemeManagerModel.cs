namespace MudDemo.Client.Models;

public class ThemeManagerModel
{
    public string[] FontFamily { get; set; } = new string[] { "Helvetica Neue eText Pro","HelveticaNeue-Light", "Roboto", "Arial" };
    public bool IsDarkMode { get; set; } = false;
    public string PrimaryColor { get; set; } = "#2d4275";
    public double BorderRadius { get; set; } = 12;
}