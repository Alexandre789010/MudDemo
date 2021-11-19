using Newtonsoft.Json;

namespace MudDemo.Client.Models.Article;

public class ArticlePreviewModel
{
    [JsonProperty]
    public int ArticleId { get; set; }
    [JsonProperty]
    public string Title { get; set; }
    [JsonProperty]
    public string Description { get; set; }
    [JsonProperty]
    public string DescriptionTrimed
    {
        get
        {
            var maxLength = 40;

            if (Description.Length > maxLength)
                return Description.Substring(0, maxLength) + "...";

            return Description;
        }
    }
}