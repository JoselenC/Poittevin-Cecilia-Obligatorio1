using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess
{
    class DataBaseRepository <T>: IRepository<T>
    {
        public void Add(T objectToAdd)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set(typeof(T));
                entity.Add(objectToAdd);
            }
        }

        public void Delete(T objectToDelete)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set(typeof(T));
                entity.Remove(objectToDelete);
            }
        }

        public T Find(Predicate<T> condition)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set(typeof(T));
                return (T) entity.Find(condition);
            }
        }

        public List<T> Get()
        {
            return new List<T>();
            using (ContextDB context = new ContextDB())
            {
                DbSet entity = context.Set(typeof(T));
                
            }
        }

        public void Set(List<T> objectToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
