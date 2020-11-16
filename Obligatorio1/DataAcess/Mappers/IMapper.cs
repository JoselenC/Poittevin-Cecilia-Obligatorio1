using System.Data.Entity;

namespace DataAccess.Mappers
{
    internal interface IMapper<D, T>
    {
        T DomainToDto(D obj);

        D DtoToDomain(T obj, DbContext context);
    }
}