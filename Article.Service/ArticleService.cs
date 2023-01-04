using Article.Core;
using Article.Model.Entities;
using Article.Repository;
using Article.Service.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ArticleEntity = Article.Model.Entities.Article;


namespace Article.Service
{
    public class ArticleService : IBaseService<ArticleDto>
    {
        protected readonly ArticleRepository _articleRepository;
        protected readonly IMapper _mapper;
        public ArticleService(ArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public IOperationResult Add(ArticleDto entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
           var article = _mapper.Map<Model.Entities.Article>(entity);
            _articleRepository.Add(article);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public IOperationResult Delete(int id)
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
            return _mapper.Map<ArticleDto>(article);
        }
        public IEnumerable<ArticleDto> GetAll()
        {
            var allArticles = _articleRepository.GetAll();
            var maplist = _mapper.Map<IEnumerable<ArticleDto>>(allArticles);
            return maplist;
        }
        public IOperationResult Update(ArticleDto entity)
        {
            if (!_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
        {
                return new OperationResult(false, "Articulo no pudo ser actulizado");
            }
            var articles = _mapper.Map<Model.Entities.Article>(entity);
            _articleRepository.Update(articles);
                return new OperationResult(true, "Articulo actulizado");
            }
        }
    }
