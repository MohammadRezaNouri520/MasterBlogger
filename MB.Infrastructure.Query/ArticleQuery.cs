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
            return _context.Articles.Include(a => a.ArticleCategory)
                .Select(a => new ArticleQueryView 
                { 
                    Id=a.Id,
                    Image=a.ImagePath,
                    Title=a.Title,
                    ShortDescription=a.ShortDescription,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory=a.ArticleCategory.Title
                }).ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles.Include(a => a.ArticleCategory)
                .Select(a => new ArticleQueryView 
                {
                    Id=a.Id,
                    Image=a.ImagePath,
                    Title=a.Title,
                    ShortDescription=a.ShortDescription,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory=a.ArticleCategory.Title,
                    Content= a.Content
                }).FirstOrDefault(a => a.Id == id);
        }
    }
}
