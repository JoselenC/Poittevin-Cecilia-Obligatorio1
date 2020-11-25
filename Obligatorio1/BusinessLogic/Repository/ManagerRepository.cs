using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public abstract class ManagerRepository : IManageRepository
    {
        public IRepository<Category> Categories;

        public IRepository<Expense> Expenses;

        public IRepository<Currency> Currencies;

        public IRepository<Budget> Budgets;

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrency(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrencyToEdit(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public void DeleteExpense(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency)
        {
            throw new NotImplementedException();
        }

        public Budget FindBudget(string month, int year)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryByName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Currency FindCurrency(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public Currency FindCurrencyByName(string CurrencyName)
        {
            throw new NotImplementedException();
        }

        public Expense FindExpense(Expense vExpense)
        {
            throw new NotImplementedException();
        }

        public List<Budget> GetBudgets()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public List<Currency> GetCurrencies()
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetExpenseByMonth(Months month)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public void SetBudget(Budget vBudget)
        {
            throw new NotImplementedException();
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            throw new NotImplementedException();
        }

        public void SetCurrency(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            throw new NotImplementedException();
        }

        public Budget UpdateBudget(Budget oldBudget, Budget newBudget)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category oldCategory, Category newCategory)
        {
            throw new NotImplementedException();
        }

        public Currency UpdateCurrency(Currency oldCurrency, Currency newCurrency)
        {
            throw new NotImplementedException();
        }

        public Expense UpdateExpense(Expense oldExpense, Expense newExpense)
        {
            throw new NotImplementedException();
        }
    }
}
