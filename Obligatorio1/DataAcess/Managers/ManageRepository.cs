using BusinessLogic;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public abstract class ManageRepository: IManageRepository
    {
        protected IRepository<Category> Categories;

        protected IRepository<Expense> Expenses;

        protected IRepository<Currency> Currencies;

        protected IRepository<Budget> Budgets;

        public Currency FindCurrency(Currency Currency)
        {
            try
            {
                return Currencies.Find(e => e.Equals(Currency));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCurrency();
            }
        }

        public void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency)
        {
            foreach (Expense expense in GetExpenses())
            {
                expense.EditCurrency(oldCurrency, newCurrency);
            }
        }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(List<string> pkeyWords)
        {
            foreach (Category category in GetCategories())
            {
                foreach (string keyWord in pkeyWords)
                {
                    if (category.CategoryContainKeyword(keyWord))
                        return true;
                }
            }
            return false;
        }

        private void AddCategory(Category category)
        {
            try
            {
                if (AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                    throw new ExcepcionInvalidRepeatedKeyWordsCategory();
                Categories.Add(category);
            }
            catch (ExceptionUnableToSaveData)
            {
                throw new ExcepcionInvalidRepeatedNameCategory();
            }
        }

        public void SetBudget(Budget vBudget)
        {
            try
            {
                Budgets.Add(vBudget);
            }
            catch (ValueNotFound)
            {
                throw new ArgumentNullException();
            }
        }

        private void AddExpense(Expense expense)
        {
            if (expense.Category == null)
                throw new ExcepcionExpenseWithEmptyCategory();
            Expenses.Add(expense);
        }

        public Currency FindCurrencyByName(string CurrencyName)
        {
            try
            {
                return Currencies.Find(e => e.IsSameCurrencyName(CurrencyName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCurrencyByName();
            }
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            Expense expense = new Expense
            {
                Amount = amount,
                CreationDate = creationDate,
                Description = description,
                Category = category,
                Currency = Currency
            };
            AddExpense(expense);
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            Category category = new Category { Name = vName, KeyWords = vKeyWords };
            AddCategory(category);
            return category;
        }

        public List<Category> GetCategories()
        {
            return Categories.Get();
        }

        public List<Expense> GetExpenses()
        {
            return Expenses.Get();
        }

        public List<Budget> GetBudgets()
        {
            return Budgets.Get();
        }

        public void DeleteExpense(Expense expense)
        {
            Expenses.Delete(expense);
        }

        public void DeleteCategory(Category category)
        {
            Categories.Delete(category);
        }

        public void DeleteCurrency(Currency Currency)
        {
            try
            {

                foreach (Expense expense in GetExpenses())
                {
                    expense.IsSameCurrencyExpense(Currency);
                }
                Currencies.Delete(Currency);
            }
            catch (ExcepcionNoDeleteCurrency)
            {
                throw new ExcepcionNoDeleteCurrency();
            }
        }

        public void DeleteCurrencyToEdit(Currency Currency)
        {
            GetCurrencies().Remove(Currency);
        }

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }

        public Budget FindBudget(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            try
            {
                return Budgets.Find(e => e.IsSameCreationDate(mMonth, year));
            }
            catch (ValueNotFound)
            {
                throw new NoFindBudget();
            }

        }
        private Category FindCategoryByDescription(string[] descriptionArray)
        {
            Category category = null;
            foreach (Category vCategory in GetCategories())
            {
                if (vCategory.IsKeyWordInDescription(descriptionArray))
                {
                    if (!(category is null))
                        throw new NoAsignCategoryByDescriptionExpense();
                    category = vCategory;
                }
            }
            if (category is null)
                throw new NoAsignCategoryByDescriptionExpense();
            return category;
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            string[] descriptionArray = vDescription.Split(' ');
            return FindCategoryByDescription(descriptionArray);
        }

        public Category FindCategoryByName(string categoryName)
        {
            try
            {
                return Categories.Find(e => e.IsSameCategoryName(categoryName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCategoryByName();
            }
        }

        public Expense FindExpense(Expense vExpense)
        {
            try
            {
                return Expenses.Find(e => e.Equals(vExpense));
            }
            catch (ValueNotFound)
            {
                throw new NoFindEqualsExpense();
            }
        }

        public List<Expense> GetExpenseByMonth(Months month)
        {
            List<Expense> expensesByMonth = new List<Expense>();
            foreach (Expense vExpense in Expenses.Get())
            {
                if (vExpense.IsExpenseSameMonth(month))
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }

        public List<Currency> GetCurrencies()
        {
            return Currencies.Get();
        }

        private bool AlreadyExistTheCurrencyName(string CurrencyName)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencyName.ToLower() == Currency.Name.ToLower())
                    exist = true;
            }
            return exist;
        }

        private bool AlreadyExistTheCurrencySymbol(string CurrencySymbol)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencySymbol.ToLower() == Currency.Symbol.ToLower())
                    exist = true;
            }
            return exist;
        }

        public void SetCurrency(Currency Currency)
        {
            if (AlreadyExistTheCurrencyName(Currency.Name))
                throw new ExceptionAlreadyExistTheCurrencyName();
            if (AlreadyExistTheCurrencySymbol(Currency.Symbol))
                throw new ExceptionAlreadyExistTheCurrencySymbol();
            Currencies.Add(Currency);
        }

        public Category UpdateCategory(Category oldCategory, Category newCategory)
        {
            return Categories.Update(oldCategory, newCategory);
        }

        public Expense UpdateExpense(Expense oldExpense, Expense newExpense)
        {
            return Expenses.Update(oldExpense, newExpense);
        }

        public Budget UpdateBudget(Budget oldBudget, Budget newBudget)
        {
            return Budgets.Update(oldBudget, newBudget);
        }

        public Currency UpdateCurrency(Currency oldCurrency, Currency newCurrency)
        {
            return Currencies.Update(oldCurrency, newCurrency);
        }
    }
}