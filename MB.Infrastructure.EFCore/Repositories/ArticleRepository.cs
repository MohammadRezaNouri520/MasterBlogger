using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }


        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles.Include(a => a.ArticleCategory)
                .Select(a => new ArticleViewModel 
                { 
                    Id=a.Id,
                    Title=a.Title,
                    CategoryName = a.ArticleCategory.Title,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDeleted=a.IsDeleted
                }).OrderByDescending(a => a.Id).ToList();
        }


        public bool Exist(string title)
        {
            return _context.Articles.Any(a => a.Title == title);
        }

        public void CreateAndSave(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Article GetBy(long id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
