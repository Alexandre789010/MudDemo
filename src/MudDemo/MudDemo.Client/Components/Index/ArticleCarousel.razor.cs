using MudBlazor;
using MudBlazor.Utilities;
using MudDemo.Client.Models.Article;

namespace MudDemo.Client.Components.Index;

public partial class ArticleCarousel : MudComponentBase
{
    private List<ArticlePreviewModel> _articles = new()
    {
        new ArticlePreviewModel
        {
            ArticleId = 0,
            Title = "Article 1 - The best so far",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
        },
        new ArticlePreviewModel
        {
            ArticleId = 1,
            Title = "Article 2 - The longest so far",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
        },
        new ArticlePreviewModel
        {
            ArticleId = 2,
            Title = "Article 3 - The shortest so far",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
        }
    };

    private int _selectedArticle = 0;

    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();

    private void NavigatePrevious()
    {
        if (_selectedArticle == 0)
            _selectedArticle = _articles.Count - 1;
        else
            _selectedArticle--;
    }

    private void NavigateNext()
    {
        if (_selectedArticle == _articles.Count - 1)
            _selectedArticle = 0;
        else
            _selectedArticle++;
    }
}