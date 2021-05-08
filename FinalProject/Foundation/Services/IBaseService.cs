using System;
using System.Collections.Generic;

namespace Foundation.Library.BaseServices
{
    public interface IBaseService<T> where T: class
    {
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IList<T> GetList();
        (int total, int totalDisplay, IList<T> records) GetListForDataTable(int pageIndex,
            int pageSize, string searchText, string orderBy);
    }
}