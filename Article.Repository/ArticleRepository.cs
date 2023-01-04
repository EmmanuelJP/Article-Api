using Article.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ArticleEntity = Article.Model.Entities.Article;
namespace Article.Repository
{
    public interface IArticleRepository
    {
        ArticleEntity Get(int id);
        IQueryable<ArticleEntity> GetAll();
        void Add(ArticleEntity entity);
        void Update(ArticleEntity entity);
        void Delete(int id);
        bool Commit();
    }
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ArticleEntity> _dbSet;
        public ArticleRepository(ArticleDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<ArticleEntity>();
        }
        public void Add(ArticleEntity entity)
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
        public ArticleEntity Get(int id)
        {
            return _dbSet.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
        }
        public IQueryable<ArticleEntity> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false);
        }
        public void Update(ArticleEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
