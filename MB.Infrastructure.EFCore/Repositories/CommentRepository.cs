using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }


        public List<CommentViewModel> GetList()
        {
            return _context.Comments
                .Include(c => c.Article)
                .Select(c => new CommentViewModel 
                {
                    Id=c.Id,
                    Name=c.Name,
                    Email=c.Email,
                    Message=c.Message,
                    ArticleTitle=c.Article.Title,
                    CreationDate=c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Status = c.Status
                }).OrderByDescending(c => c.Id).ToList();
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }

        public CommentViewModel GetBy(long id)
        {
            return _context.Comments
                .Include(c => c.Article)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Message = c.Message,
                    ArticleTitle = c.Article.Title,
                    CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Status = c.Status
                }).FirstOrDefault(c => c.Id == id);
        }

        public Comment GetForChangeStatus(long id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }
    }
}
