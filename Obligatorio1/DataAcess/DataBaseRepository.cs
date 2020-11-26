using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using DataAccess.Mappers;
using BusinessLogic;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public class DataBaseRepository <D, T>: IRepository<D> where T: class
    {
        private IMapper<D,T> mapper;
        public DataBaseRepository(IMapper<D,T> mapper)
        {
            this.mapper = mapper;
        }
        public void Add(D objectToAdd)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var TDto = mapper.DomainToDto(objectToAdd, context);
                    var entity = context.Set<T>();
                    if (context.Entry(TDto).State == EntityState.Detached)
                        entity.Add(TDto);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                throw new ExceptionUnableToSaveData();
            }
        }

        private T FindDto(Predicate<D> condition, ContextDB context)
        {
            DbSet<T> entity = context.Set<T>();
            List<T> TDtos = entity.ToList();
            foreach (var TDto in TDtos)
            {
                var DDto = mapper.DtoToDomain(TDto, context);
                var condResult = condition(DDto);
                if (condResult)
                    return TDto;
            };
            throw new ValueNotFound();
        }

        public void Delete(D objectToDelete)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set<T>();
                var ObjectToDeleteDto = FindDto(x => x.Equals(objectToDelete), context);
                entity.Remove(ObjectToDeleteDto);
                context.SaveChanges();
            }
        }

        public D Find(Predicate<D> condition)
        {
            using (ContextDB context = new ContextDB())
            {
                DbSet<T> entity = context.Set<T>();
                List<T> TDtos = entity.ToList();
                foreach (var TDto in TDtos)
                {
                    var DDto = mapper.DtoToDomain(TDto, context);
                    var condResult = condition(DDto);
                    if (condResult)
                        return DDto;
                };
                throw new ValueNotFound();
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
                    var x = mapper.DtoToDomain(item, context);
                    Dlist.Add(x);
                }
                return Dlist;
            }
        }

        public void Set(List<D> objectToAdd)
        {
            throw new NotImplementedException();
        }

        public D Update(D OldObject, D UpdatedObject)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    DbSet<T> entity = context.Set<T>();
                    T objToUpdate = FindDto(x => x.Equals(OldObject), context);
                    mapper.UpdateDtoObject(objToUpdate, UpdatedObject, context);
                    context.SaveChanges();
                    return UpdatedObject;
                }
            }
            catch (DbUpdateException)
            {
                throw new ExceptionUnableToSaveData();
            }
        }
    }
}
