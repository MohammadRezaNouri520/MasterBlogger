using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System.Collections.Generic;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
 
        public void Create(CreateComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.CreateAndSave(comment);
        }

        public CommentViewModel GetBy(long id)
        {
            return _commentRepository.GetBy(id);
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetForChangeStatus(id);
            comment.Confirm();
            _commentRepository.Save();

        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetForChangeStatus(id);
            comment.Cancel();
            _commentRepository.Save();
        }
    }
}
