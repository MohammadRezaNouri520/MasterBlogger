using System.Collections.Generic;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        void Create(CreateComment command);
        CommentViewModel GetBy(long id);
        void Confirm(long id);
        void Cancel(long id);
    }
}
