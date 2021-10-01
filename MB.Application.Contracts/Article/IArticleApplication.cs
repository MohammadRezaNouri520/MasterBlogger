using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        EditArticle GetEdit(long id);
        void Edit(EditArticle command);
        void Remove(long id);
        void Activate(long id);
    }
}
