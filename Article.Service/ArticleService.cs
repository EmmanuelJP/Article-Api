using Article.Core;
using Article.Model.Entities;
using Article.Repository;
using Article.Service.DTOs;
using System.Collections.Generic;
using System.Linq;
using ArticleEntity = Article.Model.Entities.Article;


namespace Article.Service
{
    public class ArticleService : IBaseService<ArticleDto>
    {
        protected readonly ArticleRepository _articleRepository;
        public ArticleService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public OperationResult Add(ArticleDto entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
            ArticleEntity article = new ArticleEntity
            {
                Title = entity.Title,
                Description = entity.Description
            };
            _articleRepository.Add(article);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public OperationResult Delete(int id)
        {
            if (!_articleRepository.GetAll().Where(x => x.Id == id).Any())
            {
                return new OperationResult(false, "No se pudo eliminar el articulo");
            }
            var updatedDto = GetById(id);
            Update(updatedDto);
            return new OperationResult(true, "Articulo Eliminado");
        }
        public ArticleDto GetById(int id)
        {
            var article = GetAll().Where(x => x.Id == id).FirstOrDefault();
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description
            };
        }
        public IEnumerable<ArticleDto> GetAll()
        {
            var allArticles = _articleRepository.GetAll();
            var allArticlesDtos = allArticles.Select(x => new ArticleDto()
        { 
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
            }).ToList();
            return allArticlesDtos;
        }
        public OperationResult Update(ArticleDto entity)
        {
            if (!_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
        {
                return new OperationResult(false, "Articulo no pudo ser actulizado");
            }
            ArticleEntity articles = new ArticleEntity
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
            };
            _articleRepository.Update(articles);
                return new OperationResult(true, "Articulo actulizado");
        }
    }
}