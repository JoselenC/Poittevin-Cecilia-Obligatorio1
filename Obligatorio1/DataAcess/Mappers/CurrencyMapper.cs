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
            context.Entry(obj).Collection("Currencies").Query().Load();
            return new Currency()
            {
                Name = obj.Name,
                Quotation = obj.Quotation,
                Symbol = obj.Symbol
            };
        }
    }
}
