using Article.Core;
using System;
using System.Collections.Generic;

namespace Article.Service
{
    public interface IBaseService<T> 
    {
        public T GetById(int id);
        public OperationResult Add(T entity);
        public OperationResult Update(T entity);
        public IEnumerable<T> GetAll();
        public OperationResult Delete(int id);
    }
}
