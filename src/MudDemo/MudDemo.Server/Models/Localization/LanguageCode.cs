namespace MudDemo.Server.Models.Localization;

public record LanguageCode(string Code, string DisplayName, bool IsRTL = false);



public static class LocalizationConstants
{
    public static readonly LanguageCode[] SupportedLanguages =
    {
        new("en-US", "English"),
        new("fr-FR", "French"),
        new("km_KH", "Khmer"),
        new("de-DE", "German"),
        new("nl-NL", "Dutch - Netherlands"),
        new("es-ES", "Spanish"),
        new("ru-RU", "Russian"),
        new("sv-SE", "Swedish"),
        new("id-ID", "Indonesia"),
        new("it-IT", "Italian"),
        new("zh-CN", "中文(简体)")
    };
}

