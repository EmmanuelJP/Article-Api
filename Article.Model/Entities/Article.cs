using System;

namespace Article.Model.Entities
{

    public interface IBaseEntity
    {
        public bool IsDeleted { get; set; }

    }
    public class Article : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
