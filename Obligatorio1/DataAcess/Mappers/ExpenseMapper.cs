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
            context.Entry(category).State = EntityState.Unchanged;
            context.Entry(currency).State = EntityState.Unchanged;

            DbSet <ExpenseDto> expenseDtoSet = context.Set<ExpenseDto>();
            ExpenseDto expenseDto = expenseDtoSet
                .Where(x => x.Description == obj.Description)
                .Where(x => x.Amount == obj.Amount)
                .Where(x => x.CreationDate == obj.CreationDate)
                .Where(x=>x.CreationDate.Hour==obj.CreationDate.Hour && x.CreationDate.Minute==obj.CreationDate.Minute && x.CreationDate.Second==obj.CreationDate.Second)
                .FirstOrDefault();
           
            if (expenseDto is null)
            {
                expenseDto = new ExpenseDto()
                {
                    Description = obj.Description,
                    Amount = obj.Amount,
                    CreationDate = obj.CreationDate,
                    Category = categoryMapper.DomainToDto(obj.Category, context),
                    Currency = currencyMapper.DomainToDto(obj.Currency, context)
                };

            }
            else
            {
                context.Entry(expenseDto).State = EntityState.Modified;
                context.Entry(expenseDto).Reference("Category").Load();
                context.Entry(expenseDto).Reference("Money").Load();
                //context.Entry(expenseDto).Reference("Category").Load();
                context.Entry(expenseDto).State = EntityState.Modified;
            }

            return expenseDto;
        }

        public Expense DtoToDomain(ExpenseDto obj, DbContext context)
        {

            CategoryMapper categoryMapper = new CategoryMapper();
            CurrencyMapper currencyMapper = new CurrencyMapper();
            context.Entry(obj).Reference("Currency").Query().Load();
            context.Entry(obj).Reference("Category").Query().Load();
            return new Expense()
            {
                Description = obj.Description,
                Amount = obj.Amount,
                CreationDate = obj.CreationDate,
                Category = categoryMapper.DtoToDomain(obj.Category, context),
                Currency = currencyMapper.DtoToDomain(obj.Currency, context)
            };
        }

        public ExpenseDto UpdateDtoObject(ExpenseDto objToUpdate, Expense updatedObject, DbContext contex)
        {
            throw new NotImplementedException();
        }
    }
}

