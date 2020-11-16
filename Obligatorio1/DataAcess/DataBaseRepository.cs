using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using DataAccess.Mappers;
using BusinessLogic;

namespace DataAccess
{
    class DataBaseRepository <D, T>: IRepository<D> where T: class
    {
        private IMapper<D,T> mapper;
        public DataBaseRepository(IMapper<D,T> mapper)
        {
            this.mapper = mapper;
        }
        public void Add(D objectToAdd)
        {
            using (ContextDB context = new ContextDB())
            {
                var TDto = mapper.DomainToDto(objectToAdd);
                var entity = context.Set<T>();
                entity.Add(mapper.DomainToDto(objectToAdd));
                context.SaveChanges();
            }
        }

        public void Delete(D objectToDelete)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set<T>();
                entity.Remove(mapper.DomainToDto(objectToDelete));
                context.SaveChanges();
            }
        }

        public D Find(Predicate<D> condition)
        {
            using (ContextDB context = new ContextDB())
            {
                DbSet<T> entity = context.Set<T>();
                T TDto;
                try
                {
                    TDto = entity.ToList().First(x => condition(mapper.DtoToDomain(x, context)));
                }
                catch (InvalidOperationException)
                {
                    throw new ValueNotFound();
                }
                return mapper.DtoToDomain(TDto, context);
            }
        }

        public List<D> Get()
        {
            using (ContextDB context = new ContextDB())
            {
                DbSet<T> entity = context.Set<T>();
                List<D> Dlist = new List<D>();
                foreach (T item in entity.ToList())
                {
                    Dlist.Add(mapper.DtoToDomain(item, context));
                }
                return Dlist;
            }
        }

        public void Set(List<D> objectToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
