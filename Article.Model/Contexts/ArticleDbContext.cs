<<<<<<< Updated upstream
﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Article.Model.Entities;
=======
﻿using Article.Model.Entities;
using Article.Model.Extentions;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes


namespace Article.Model.ArticleDbContext
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Entities.Article> Article { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=Tienda;Uid=root;Pwd=Code4321,;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
    }
   
}

