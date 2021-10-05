using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {

        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {
        }
        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GaurdAgainstEmptyTitle(title);
            validatorService.CheckThisRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
        }

        public void GaurdAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Rename(string title)
        {
            GaurdAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }


    }
}