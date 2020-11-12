using System;
using System.Collections.Generic;
using System.Threading;

namespace BusinessLogic
{
   
    public class MemoryRepository
    {
        private Repository<Category> Categories;

        private Repository<Expense> Expenses;

        private Repository<Budget> Budgets;

        private Repository<Currency> Currencies;


        public MemoryRepository()
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            Currencies = new Repository<Currency>();
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Currencies.Add(currency);
        }     

        public MemoryRepository(List<Category> vCategories)
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            Currencies = new Repository<Currency>();
            Categories.Set(vCategories);
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Currencies.Add(currency);
        }

        public Currency FindCurrency(Currency currency)
        {
            try
            {
                return Currencies.Find(e => e.Equals(currency));
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

        private bool AlreadyExistTheCategoryName(string categoryName)
        {
            bool exist = true ;
            foreach (Category category in GetCategories())
            {
                if (categoryName.ToLower() == category.Name.ToLower())
                   exist= false;
            }
            return exist;
        }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(KeyWord pkeyWords)
        {            
            foreach (Category category in GetCategories())
            {
                if (category.CategoryContainKeyword(pkeyWords))
                    return true;
            }
            return false;
        }       

        private void AddCategory(Category category)
        {
            if (!AlreadyExistTheCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            if (AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            Categories.Add(category);
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

        public Currency FindCurrency(string currencyName)
        {
            try
            {
                return Currencies.Find(e => e.IsSameCurrencyName(currencyName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCurrencyByName();
            }
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category,Currency currency)
        {
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description, Category = category,Currency=currency };
            AddExpense(expense);
        }

        public Category SetCategory(string vName,List<string> vKeyWords )
        {
            KeyWord pKeyWord = new KeyWord(vKeyWords);
            Category category = new Category { Name = vName, KeyWords = pKeyWord };
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

        public void DeleteCurrency(Currency currency)
        {
            try
            {

                foreach (Expense expense in GetExpenses())
                {
                    expense.IsSameCurrencyExpense(currency);
                }
                Currencies.Delete(currency);
            }
            catch(ExcepcionNoDeleteCurrency)
            {
                throw new ExcepcionNoDeleteCurrency();
            }
        }

        public void DeleteCurrencyToEdit(Currency currency)
        {
            GetCurrencies().Remove(currency);
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
            catch (ValueNotFound) {
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

        private bool AlreadyExistTheCurrencyName(string currencyName)
        {
            bool exist = false;
            foreach (Currency currency in GetCurrencies())
            {
                if (currencyName.ToLower() == currency.Name.ToLower())
                    exist = true;
            }
            return exist;
        }

        private bool AlreadyExistTheCurrencySymbol(string currencySymbol)
        {
            bool exist = false;
            foreach (Currency currency in GetCurrencies())
            {
                if (currencySymbol.ToLower() == currency.Symbol.ToLower())
                    exist = true;
            }
            return exist;
        }

        public void SetCurrency(Currency currency)
        {
            if (AlreadyExistTheCurrencyName(currency.Name))
                throw new ExceptionAlreadyExistTheCurrencyName();
            if(AlreadyExistTheCurrencySymbol(currency.Symbol))
                throw new ExceptionAlreadyExistTheCurrencySymbol();
            Currencies.Add(currency);
        }


    }
}