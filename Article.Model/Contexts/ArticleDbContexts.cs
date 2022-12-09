using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Article.Model.ArticleDbContext
{
    public class ArticleDbContexts : DbContext
    {
        public DbSet<Entities.Article> Article { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=ToDoTask;Uid=root;Pwd=Code4321,;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
   
}

