using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Article.Model.Entities;


namespace Article.Model.ArticleDbContext
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Articles> Article { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=Tienda;Uid=root;Pwd=Code4321,;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
   
}

