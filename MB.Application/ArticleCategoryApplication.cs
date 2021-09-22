﻿using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
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
    }
}