using System.Data.Entity;

namespace DataAccess.Mappers
{
    internal interface IMapper<D, T>
    {
        T DomainToDto(D obj, DbContext context);

        D DtoToDomain(T obj, DbContext context);
    }
}