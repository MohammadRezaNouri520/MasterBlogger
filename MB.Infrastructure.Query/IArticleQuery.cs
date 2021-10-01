using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView GetArticle(long id);
    }
}
