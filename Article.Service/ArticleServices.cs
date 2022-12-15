using Article.Core;
using Article.Model.Entities;
using Article.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Article.Service
{
    public class ArticleServices : IBaseService<Model.Entities.Article>
    {
        protected readonly ArticleRepository _articleRepository;
        public ArticleServices(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public OperationResult Add(Model.Entities.Article entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
            _articleRepository.Add(entity);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public OperationResult Delete(int id)
        {
            var isItDeleted = _articleRepository.GetAll().Where(x => x.Id == id).Any();
            if (!isItDeleted)
            {
                return new OperationResult(false, "No se pudo eliminar el articulo");
            }
            var item = GetById(id);
            item.IsDeleted = true;
            Update(item);
            return new OperationResult(true, "Articulo Eliminado");
        }
        public Model.Entities.Article GetById(int id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<Model.Entities.Article> GetAll()
        { 
            return _articleRepository.GetAll();
        }
        public OperationResult Update(Model.Entities.Article entity)
        {
            if (_articleRepository.GetAll().Where(x => x.Id == entity.Id && entity.IsDeleted == false).Any())
            {
                _articleRepository.Update(entity);
                return new OperationResult(true, "Articulo actulizado");
            }
            
            return new OperationResult(true, "Articulo no pudo ser actulizado");
        }
    }
}