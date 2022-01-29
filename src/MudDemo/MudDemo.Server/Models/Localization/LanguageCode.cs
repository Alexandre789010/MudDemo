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
        new("ja-JP", "Japanese"),
        new("es-ES", "Spanish"),
        new("ru-RU", "Russian"),
        new("zh-CN", "Simplified Chinese")
    };
}

