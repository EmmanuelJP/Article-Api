﻿using System;

namespace Article.Model.Entities
{
    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}