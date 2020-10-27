using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Repository <T>
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
            if(objectToAdd==null)
                throw new ValueNotFound();
            repository.Add(objectToAdd);
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

    }
}
