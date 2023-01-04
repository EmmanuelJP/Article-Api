using Microsoft.EntityFrameworkCore;


namespace Article.Model.Contexts
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Entities.Article> Article { get; set; }
        public ArticleDbContext(){
        }
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
        }
    }
}

