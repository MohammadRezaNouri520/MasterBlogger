using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Where(a => a.IsDeleted==false)
                .Include(a => a.ArticleCategory)
                .Include(a => a.Comments)
                .Select(a => new ArticleQueryView 
                { 
                    Id=a.Id,
                    Image=a.ImagePath,
                    Title=a.Title,
                    ShortDescription=a.ShortDescription,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory=a.ArticleCategory.Title,
                    CommentCount=a.Comments.Count(c => c.Status==Statuses.Confirm)
                }).ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Where(a => a.IsDeleted == false)
                .Include(a => a.ArticleCategory)
                .Include(a => a.Comments)
                .Select(a => new ArticleQueryView
                {
                    Id = a.Id,
                    Image = a.ImagePath,
                    Title = a.Title,
                    ShortDescription = a.ShortDescription,
                    CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory = a.ArticleCategory.Title,
                    Message = a.Content,
                    CommentCount = a.Comments.Count(c => c.Status == Statuses.Confirm),
                    Comments = MapComments(a.Comments.Where(x => x.Status==Statuses.Confirm))
                }).FirstOrDefault(a => a.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(c => new CommentQueryView 
            {
                Name=c.Name,
                CreationDate=c.CreationDate.ToString(CultureInfo.InvariantCulture),
                Message=c.Message
            }).ToList();
        }
    }
}
