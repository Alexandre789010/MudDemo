using MudDemo.Client.Models.Article;

namespace MudDemo.Client.Services;

public interface IArticlesService
{
    Task<IEnumerable<ArticlePreviewModel>> GetArticles();
}