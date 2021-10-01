using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.AspNetCoreRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Articles = _articleQuery.GetArticles();
        }
    }
}