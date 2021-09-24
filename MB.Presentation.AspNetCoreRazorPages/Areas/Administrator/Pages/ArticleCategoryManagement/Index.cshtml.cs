using System.Collections.Generic;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.AspNetCoreRazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }

        public RedirectToPageResult OnGetDelete(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        // 1st way:
        public RedirectToPageResult OnGetActivate(long id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("./Index");
        }

        // 2nd way:
        //public RedirectToPageResult OnPostActivate(long id)
        //{
        //    _articleCategoryApplication.Activate(id);
        //    return RedirectToPage("./Index");
        //}
    }
}
