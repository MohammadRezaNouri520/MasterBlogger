using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.AspNetCoreRazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public SelectList ArticleCategories { get; set; }
        
        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetSelectList(), "Id", "Title");
        }

        public RedirectToPageResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
