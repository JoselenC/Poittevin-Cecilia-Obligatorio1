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
    class ExpenseMapper : IMapper<Expense, ExpenseDto>
    {
        public ExpenseMapper()
        {

        }

        public ExpenseDto DomainToDto(Expense obj, DbContext context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            CurrencyMapper currencyMapper = new CurrencyMapper();
            CategoryDto category = categoryMapper.DomainToDto(obj.Category, context);
            CurrencyDto currency = currencyMapper.DomainToDto(obj.Currency, context);
            context.Entry(category).State = EntityState.Modified;
            context.Entry(currency).State = EntityState.Modified;
            return new ExpenseDto()
            {
                Description = obj.Description,
                Amount = obj.Amount,
                CreationDate = obj.CreationDate,
                Category = category,
                Currency = currency
            };
        }

        public Expense DtoToDomain(ExpenseDto obj, DbContext context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            CurrencyMapper currencyMapper = new CurrencyMapper();
            
            return new Expense()
            {
                Description = obj.Description,
                Amount = obj.Amount,
                CreationDate = obj.CreationDate,
                Category = categoryMapper.DtoToDomain(obj.Category, context),
                Currency = currencyMapper.DtoToDomain(obj.Currency, context)
            };
        }
    }
}

