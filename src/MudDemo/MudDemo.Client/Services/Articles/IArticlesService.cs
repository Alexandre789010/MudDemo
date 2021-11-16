using MudDemo.Client.Models.Article;

namespace MudDemo.Client.Services;

public interface IArticlesService
{
    Task<List<ArticlePreviewModel>> GetArticles();
}