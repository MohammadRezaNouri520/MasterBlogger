using MB.Domain.ArticleCategoryAgg.Services;
using System;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GaurdAgainstEmptyTitle(title);
            validatorService.CheckThisRecordAlreadyExists(title);
            Title = title;
            CreationDate = DateTime.Now;
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