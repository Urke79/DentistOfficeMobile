using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void SaveEntity(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
    }
}
