using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Model.DTOs
{
    public class AriclesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public AriclesDto()
        {

        }
    }
    
}
