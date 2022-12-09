﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Article.Model.Entities;


namespace Article.Model.ArticleDbContext
{
    public class ArticleDbContexts : DbContext
    {
        public DbSet<Entities.Article> Article { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=Article;Uid=root;Pwd=123456789;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
   
}

