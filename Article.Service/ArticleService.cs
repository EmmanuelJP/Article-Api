using Article.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Article.Service
{
    internal class ArticleService : IBaseService<Model.Entities.Article>
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<Model.Entities.Article> _dbSet;
        public ArticleService(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Model.Entities.Article>();
        }
        public OperationResult Add(Model.Entities.Article entity)
        {
            if (_dbSet.Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El Articulo existe");
            }
            _dbSet.Add(entity);
            return new OperationResult(true, "El Articulo ha sido agregado");
        }
        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
        public OperationResult Delete(int id)
        {
            if (_dbSet.Where(x => x.Id == id).Any())
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
            return _dbSet.Where(x => x.IsDeleted == false);
        }
        public OperationResult Update(Model.Entities.Article entity)
        {
            if (_dbSet.Where(x => x.Id == entity.Id).Any())
            {
                return new OperationResult(false, "El articulo no se pudo actualizar");
            }
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
            return new OperationResult(true, "Articulo Actualizada");
        }
    }
}