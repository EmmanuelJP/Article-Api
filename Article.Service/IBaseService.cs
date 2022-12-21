using Article.Core;
using System;
using System.Collections.Generic;

namespace Article.Service
{
    public interface IBaseService<EntityDto> 
    {
        public EntityDto GetById(int id);
        public OperationResult Add(EntityDto entity);
        public OperationResult Update(EntityDto entity);
        public IEnumerable<EntityDto> GetAll();
        public OperationResult Delete(int id);
    }
}
