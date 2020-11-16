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
        public ExpenseDto DomainToDto(Expense obj)
        {
            throw new NotImplementedException();
        }

        public Expense DtoToDomain(ExpenseDto obj, DbContext context)
        {
            throw new NotImplementedException();
        }
    }
}
