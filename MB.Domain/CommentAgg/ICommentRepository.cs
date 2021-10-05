using MB.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        List<CommentViewModel> GetList();
        void CreateAndSave(Comment entity);
        void Save();
        CommentViewModel GetBy(long id);
        Comment GetForChangeStatus(long id);
    }
}
