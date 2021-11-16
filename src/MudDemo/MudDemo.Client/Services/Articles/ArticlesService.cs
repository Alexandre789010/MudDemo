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

    public async Task<List<ArticlePreviewModel>> GetArticles()
    {
        var articles = await _httpClient.GetFromJsonAsync<List<ArticlePreviewModel>>(UriRequest);
        return articles ?? throw new InvalidOperationException();
    }
}