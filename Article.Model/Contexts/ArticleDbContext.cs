using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Article.Model.Entities;


namespace Article.Model.ArticleDbContext
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Entities.Article> Article { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=Article;user=root;password=123456789");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
   
}

