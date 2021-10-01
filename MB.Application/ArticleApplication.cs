using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _validatorService;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService validatorService)
        {
            _articleRepository = articleRepository;
            _validatorService = validatorService;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ImagePath, command.ShortDescription,
                command.Content, command.ArticleCategoryId, _validatorService);
            _articleRepository.CreateAndSave(article);
        }

        public EditArticle GetEdit(long id)
        {
            var article = _articleRepository.GetBy(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ArticleCategoryId = article.CategoryId,
                ImagePath = article.ImagePath,
                ShortDescription = article.ShortDescription,
                Content = article.Content
            };
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.GetBy(command.Id);
            article.Edit(command.Title, command.ImagePath, command.ShortDescription, command.Content, command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public void Remove(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Remove();
            _articleRepository.Save();
        }

        public void Activate(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Activate();
            _articleRepository.Save();
        }
    }
}
