using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System.Collections.Generic;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }


        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel 
                { 
                    Id=articleCategory.Id,
                    Title=articleCategory.Title,
                    CreationDate=articleCategory.CreationDate.ToString(),
                    IsDeleted=articleCategory.IsDeleted
                });
            }
            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategroy = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Add(articleCategroy);
        }

        public RenameArticleCategory GetBy(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            return new RenameArticleCategory 
            { 
                Id=articleCategory.Id,
                Title=articleCategory.Title
            };
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }
    }
}
