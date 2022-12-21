using Article.Core;
using Article.Model.DTOs;
using Article.Model.Entities;
using Article.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Article.Service
{
    public class ArticleServices : IBaseService<ArticleDto>
    {
        protected readonly ArticleRepository _articleRepository;
        public ArticleServices(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public OperationResult Add(ArticleDto entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
            Model.Entities.Article article = new Model.Entities.Article { Title = entity.Title, Description = entity.Description };
            _articleRepository.Add(article);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public OperationResult Delete(int id)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == id).Any())
            {
                return new OperationResult(false, "No se pudo eliminar el articulo");
            }
            var item = GetById(id);
            item.IsDeleted = true;
            Update(item);
            return new OperationResult(true, "Articulo Eliminado");
        }
        public ArticleDto GetById(int id)
        {
            var article = GetAll().Where(x => x.Id == id).FirstOrDefault();
            return new ArticleDto { Id = article.Id, Title = article.Title, Description = article.Description };
        }
        public IEnumerable<ArticleDto> GetAll()
        {
            var allArticles = _articleRepository.GetAll().Where(x => x.IsDeleted == false);
            var allArticlesDtos = allArticles.Select(x => new ArticleDto()
            {
                Description =
                x.Description,
                Title = x.Title,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            })
                .ToList();
            return allArticlesDtos;
        }
        public OperationResult Update(ArticleDto entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                Model.Entities.Article articles = new Model.Entities.Article { Id = entity.Id, Title = entity.Title, Description = entity.Description, IsDeleted = entity.IsDeleted };
                _articleRepository.Update(articles);
                return new OperationResult(true, "Articulo actulizado");
            }

            return new OperationResult(true, "Articulo no pudo ser actulizado");
        }
    }
}