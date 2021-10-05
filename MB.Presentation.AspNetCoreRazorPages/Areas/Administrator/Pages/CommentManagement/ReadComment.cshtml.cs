using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.AspNetCoreRazorPages.Areas.Administrator.Pages.CommentManagement
{
    public class ReadCommentModel : PageModel
    {
        public CommentViewModel Comment { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ReadCommentModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Comment = _commentApplication.GetBy(id);
        }
    }
}
