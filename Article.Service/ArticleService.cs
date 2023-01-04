using Article.Core;
using Article.Repository;
using Article.Service.DTOs;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ArticleEntity = Article.Model.Entities.Article;


namespace Article.Service
{
    public class ArticleService : IBaseService<ArticleDto>
    {
        protected readonly IArticleRepository _articleRepository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<ArticleDto> _validator;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper, IValidator<ArticleDto> validator)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public IOperationResult Add(ArticleDto entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid)
            {
                return new OperationResult(true, "Data invalid");
            }
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
            var article = _mapper.Map<ArticleEntity>(entity);
            _articleRepository.Add(article);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public IOperationResult Delete(int id)
        {
            if (!_articleRepository.GetAll().Where(x => x.Id == id).Any())
            {
                return new OperationResult(false, "No se pudo eliminar el articulo");
            }
            _articleRepository.Delete(id);
            return new OperationResult(true, "Articulo Eliminado");
        }
        public ArticleDto GetById(int id)
        {
            var article = _articleRepository.Get(id);
            return _mapper.Map<ArticleDto>(article);
        }
        public IEnumerable<ArticleDto> GetAll()
        {
            var allArticles = _articleRepository.GetAll();
            var maplist = _mapper.Map<IEnumerable<ArticleDto>>(allArticles);
            return maplist;
        }
        public IOperationResult Update(ArticleDto dto)
        {
            var results = _validator.Validate(dto);
            if (!results.IsValid)
            {
              return new OperationResult(true,"Data invalid"); 
            }
            if (!_articleRepository.GetAll().Where(x => x.Id == dto.Id).Any())
                return new OperationResult(false, "Articulo no pudo ser actulizado");

            var entity = _articleRepository.Get(dto.Id);
            _mapper.Map(dto, entity);


            _articleRepository.Update(entity);
            return new OperationResult(true, "Articulo actulizado");
        }
    }
}
