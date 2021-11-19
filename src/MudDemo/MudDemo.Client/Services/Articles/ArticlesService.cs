using MudDemo.Client.Models.Article;
using System.Net.Http.Json;

namespace MudDemo.Client.Services;

public class ArticlesService : IArticlesService
{
    private const string UriRequest = "sample-data/articles.json";
    private readonly HttpClient _httpClient;

    public ArticlesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ArticlePreviewModel>> GetArticles()
    {
        var articles = await _httpClient.GetFromJsonAsync<IEnumerable<ArticlePreviewModel>>(UriRequest);
        return articles ?? throw new InvalidOperationException();
    }
}