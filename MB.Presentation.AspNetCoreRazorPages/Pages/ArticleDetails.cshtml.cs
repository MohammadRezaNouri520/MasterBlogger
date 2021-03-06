using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.AspNetCoreRazorPages.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery;

        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPost(CreateComment command)
        {
            _commentApplication.Create(command);
            return RedirectToPage("./ArticleDetails", new { id = command.ArticleId });
        }
    }
}