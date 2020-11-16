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

        public ExpenseDto DomainToDto(Expense obj)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            CurrencyMapper currencyMapper = new CurrencyMapper();
            return new ExpenseDto()
            {
                Description = obj.Description,
                Amount = obj.Amount,
                CreationDate = obj.CreationDate,
                Category = categoryMapper.DomainToDto(obj.Category),
                Currency = currencyMapper.DomainToDto(obj.Currency)
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
                Currency = currencyMapper.DtoToDomain(obj.Currency, context),
                CreationDate = obj.CreationDate,
                Category = categoryMapper.DtoToDomain(obj.Category, context),
            };
        }
    }
}

