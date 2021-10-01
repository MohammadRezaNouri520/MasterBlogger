using MB.Application.Contracts.Article;
using System.Collections.Generic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetAll();
        void CreateAndSave(Article entity);
        Article GetBy(long id);
        
        bool Exist(string title);
        void Save();
    }
}
