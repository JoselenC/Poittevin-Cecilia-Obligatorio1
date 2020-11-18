using BusinessLogic;
using DataAccess.Mappers;
using DataAcess.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mappers
{
    class CurrencyMapper : IMapper<Currency, CurrencyDto>
    {
        public CurrencyDto DomainToDto(Currency obj, DbContext context)
        {
            return new CurrencyDto()
            {
                Name = obj.Name,
                Quotation = obj.Quotation,
                Symbol = obj.Symbol
            };
        }

        public Currency DtoToDomain(CurrencyDto obj, DbContext context)
        {
            return new Currency()
            {
                Name = obj.Name,
                Quotation = obj.Quotation,
                Symbol = obj.Symbol
            };
        }

        public CurrencyDto UpdateDtoObject(CurrencyDto objToUpdate, Currency updatedObject, DbContext contex)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Quotation = updatedObject.Quotation;
            objToUpdate.Symbol = updatedObject.Symbol;
            return objToUpdate;
        }
    }
}
