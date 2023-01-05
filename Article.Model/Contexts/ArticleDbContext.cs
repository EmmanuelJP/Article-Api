<<<<<<< Updated upstream
﻿using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Text;
using Article.Model.Entities;
=======
﻿using Article.Model.Entities;
using Article.Model.Extentions;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes
=======
>>>>>>> main


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

