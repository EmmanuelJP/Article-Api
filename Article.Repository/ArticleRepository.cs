using Article.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ArticleEntity = Article.Model.Entities.Article;
namespace Article.Repository
{
    public interface IArticleRepository
    {
        bool Any(int id);
        ArticleEntity Get(int id);
        IQueryable<ArticleEntity> GetAll();
        void Add(ArticleEntity entity);
        void Update(ArticleEntity entity);
        void Delete(int id);
        bool Commit();
    }
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext _dbContext;
        private readonly DbSet<ArticleEntity> _dbSet;
        public ArticleRepository(ArticleDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Article;
        }
        public void Add(ArticleEntity entity)
        {
            _dbSet.Add(entity);
            Commit();
        }

        public bool Any(int id)
        {
            return GetAll().Any(x => x.Id == id);
        }

        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
        public void Delete(int id)
        {
            var item = Get(id);
            _dbContext.Remove(item);
            Commit();
        }
        public ArticleEntity Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
        public IQueryable<ArticleEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public void Update(ArticleEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
