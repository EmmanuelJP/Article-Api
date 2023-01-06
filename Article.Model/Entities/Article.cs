using System;

namespace Article.Model.Entities
{
    public interface IAuditEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public interface ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }

    }
    public interface IBaseEntity 
    {
        public int Id { get; set; }
    }

    public class Article : IBaseEntity, ISoftDeleteEntity, IAuditEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        #region Properties
        public string Title { get; set; }
        public string Description { get; set; }
        #endregion
       
        #region Auditable Entities
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        #endregion
    }
}
