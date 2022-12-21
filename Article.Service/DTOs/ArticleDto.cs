using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Service.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public ArticleDto()
        {

        }
    }
    
}
