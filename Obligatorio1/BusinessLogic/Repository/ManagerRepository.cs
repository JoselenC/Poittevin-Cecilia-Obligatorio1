using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public abstract class ManagerRepository
    {
        public IRepository<Category> Categories;

        public IRepository<Expense> Expenses;

        public IRepository<Currency> Currencies;

        public IRepository<Budget> Budgets;

    }
}
