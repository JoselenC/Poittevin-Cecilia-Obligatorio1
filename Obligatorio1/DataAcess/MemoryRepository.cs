using BusinessLogic;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    class MemoryRepository <T>: IRepository<T> 
    {
        List<T> repository = new List<T>();

        public T Find(Predicate<T> condition)
        {
            T retorno = repository.Find(condition);
            if (retorno == null)
            {
                throw new ValueNotFound();
            }
            return retorno;
        }

        public void Add(T objectToAdd)
        {                
            try
            {
                repository.Add(objectToAdd);
            }
            catch (ArgumentNullException)
            {
                throw new ValueNotFound();
            }
        }

        public List<T> Get()
        {
            return repository;
        }

        public void Delete(T objectToDelete)
        {
            repository.Remove(objectToDelete);
        }

        public void Set(List<T> objectToAdd)
        {
            repository = objectToAdd;
        }

        public T Update(T OldObject, T UpdatedObject)
        {
            return UpdatedObject;
        }
    }

}
