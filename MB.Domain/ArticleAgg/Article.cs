using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using System;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ImagePath { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        
        // Navigation Property
        public long CategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
        }

        public Article(string title, string imagePath, string shortDescription, string content, long categoryId, IArticleValidatorService validatorService)
        {
            Validator(title, categoryId);
            validatorService.CheckThatThisRecordAlreadyExist(title);
            Title = title;
            ImagePath = imagePath;
            ShortDescription = shortDescription;
            Content = content;
            CategoryId = categoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }
        public void Edit(string title, string imagePath, string shortDescription, string content, long categoryId)
        {
            Validator(title, categoryId);

            Title = title;
            ImagePath = imagePath;
            ShortDescription = shortDescription;
            Content = content;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        private void Validator(string title, long categoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("Title can not be empty!");
            if (categoryId == 0)
                throw new ArgumentNullException("CategoryId can not be empty or zero!");
        }
    }
}
