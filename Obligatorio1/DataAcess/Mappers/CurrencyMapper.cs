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
    public class CurrencyMapper : IMapper<Currency, CurrencyDto>
    {
        public CurrencyDto DomainToDto(Currency obj, DbContext context)
        {
            DbSet<CurrencyDto> CurrencySet = context.Set<CurrencyDto>();
            CurrencyDto currencyDto = CurrencySet
                                               .Where(x => x.Name == obj.Name)
                                               .Where(x => x.Quotation == obj.Quotation)
                                               .Where(x => x.Symbol == obj.Symbol)
                                               .FirstOrDefault();
          
            if(currencyDto is null)
            return new CurrencyDto()
            {
                Name = obj.Name,
                Quotation = obj.Quotation,
                Symbol = obj.Symbol
            };
            return currencyDto;
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
