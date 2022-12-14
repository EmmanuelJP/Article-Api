using Article.Model.ArticleDbContext;
using Article.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Article.Repository
{
    public interface IArticleRepository
    {
        Model.Entities.Article Get(int id);
        IQueryable<Model.Entities.Article> GetAll();
        void Add(Model.Entities.Article entity);
        void Update(Model.Entities.Article entity);
        void Delete(int id);
        bool Commit();
    }
    public class ArticleRepository : IArticleRepository
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<Model.Entities.Article> _dbSet;
        public ArticleRepository(ArticleDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Model.Entities.Article>();
        }
        public void Add(Model.Entities.Article entity)
        {
            _dbSet.Add(entity);
            Commit();
        }
        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
        public void Delete(int id)
        {
            var item = Get(id);
            item.IsDeleted = true;
            Update(item);
        }
        public Model.Entities.Article Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
        public IQueryable<Model.Entities.Article> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false);
        }
        public void Update(Model.Entities.Article entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
