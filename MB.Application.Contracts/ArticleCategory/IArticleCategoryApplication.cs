using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory command);
        RenameArticleCategory GetBy(long id);
        void Rename(RenameArticleCategory command);
        void Remove(long id);
        void Activate(long id);

        List<ArticleCategorySelectList> GetSelectList();
    }
}
