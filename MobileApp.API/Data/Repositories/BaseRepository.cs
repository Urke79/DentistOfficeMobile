using Microsoft.EntityFrameworkCore;
using MobileApp.API.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MobileApp.API.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    { 
        public IEnumerable<T> GetAll()
        {
            using (var db = new AppDbContext())
            {
                return db.Set<T>().ToList();
            }          
        }

        public T GetById(object id)
        {
            using (var db = new AppDbContext())
            {
                return db.Set<T>().Find(id);
            }           
        }

        public void SaveEntity(T entity)
        {
            using (var db = new AppDbContext())
            {
                 db.Set<T>().Add(entity);
                 db.SaveChanges();
            }
        }

        public void UpdateEntity(T entity)
        {
            using (var db = new AppDbContext())
            {
                db.Set<T>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteEntity(T entity)
        {
            using (var db = new AppDbContext())
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }
    }
}
