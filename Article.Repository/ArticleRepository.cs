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
        Articles Get(int id);
        IQueryable<Articles> GetAll();
        void Add(Articles entity);
        void Update(Articles entity);
        void Delete(int id);
        bool Commit();
    }
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Articles> _dbSet;
        public ArticleRepository(ArticleDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Articles>();
        }
        public void Add(Articles entity)
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
        public Articles Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
        public IQueryable<Articles> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false);
        }
        public void Update(Articles entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
