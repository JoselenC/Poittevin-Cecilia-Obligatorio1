using BusinessLogic;
using DataAccess;
using DataAcess.DBObjects;
using DataAcess.Mappers;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace DataAcces
{
    public class DataBaseManagerRepository : ManageRepository
    {
        public DataBaseManagerRepository()
        {
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            Expenses = new DataBaseRepository<Expense, ExpenseDto>(new ExpenseMapper());
            Budgets = new DataBaseRepository<Budget, BudgetDto>(new BudgetMapper());
            Currencies = new DataBaseRepository<Currency, CurrencyDto>(new CurrencyMapper());
            try
            {
                Currency money = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
                Currencies.Add(money);
            }
            catch (ExceptionUnableToSaveData) {}
        }
    }
}
