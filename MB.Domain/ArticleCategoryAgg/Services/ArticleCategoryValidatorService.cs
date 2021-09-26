using MB.Domain.ArticleCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new DuplicatedRecordException($"This record is already exists in database");
        }
    }
}
