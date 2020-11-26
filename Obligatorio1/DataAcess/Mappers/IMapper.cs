using System.Data.Entity;

namespace DataAccess.Mappers
{
    public interface IMapper<D, T>
    {
        T DomainToDto(D obj, DbContext context);

        D DtoToDomain(T obj, DbContext context);

        T UpdateDtoObject(T objToUpdate, D updatedObject, DbContext contex);
    }
}