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

        private Repository<Money> Monies;


        public MemoryRepository()
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            Monies = new Repository<Money>();
            Money money = new Money() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Monies.Add(money);
        }     

        public MemoryRepository(List<Category> vCategories)
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            Monies = new Repository<Money>();
            Categories.Set(vCategories);
            Money money = new Money() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Monies.Add(money);
        }

        public Money FindMoney(Money money)
        {
            try
            {
                return Monies.Find(e => e.Equals(money));
            }
            catch (ValueNotFound)
            {
                throw new NoFindMoney();
            }
            
          
        }

        public void EditMoneyAllExpense(Money oldMoney, Money newMoney)
        {            
            foreach (Expense expense in GetExpenses())
            {
                expense.EditMoney(oldMoney, newMoney);
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

        public Money FindMoneyByName(string moneyName)
        {
            try
            {
                return Monies.Find(e => e.IsSameMoneyName(moneyName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindMoneyByName();
            }
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category,Money money)
        {
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description, Category = category,Money=money };
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

        public void DeleteMoney(Money money)
        {
            try
            {
                foreach (Expense expense in GetExpenses())
                {
                    expense.HaveMoney(money);
                }
                Monies.Delete(money);
            }
            catch(ExcepcionNoDeleteMoney)
            {
                throw new ExcepcionNoDeleteMoney();
            }
        }

        public void DeleteMoneyToEdit(Money money)
        {
            GetMonies().Remove(money);
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

        public List<Money> GetMonies()
        {
            return Monies.Get();
        }

        private bool AlreadyExistTheMoneyName(string moneyName)
        {
            bool exist = false;
            foreach (Money money in GetMonies())
            {
                if (moneyName.ToLower() == money.Name.ToLower())
                    exist = true;
            }
            return exist;
        }

        private bool AlreadyExistTheMoneySymbol(string moneySymbol)
        {
            bool exist = false;
            foreach (Money money in GetMonies())
            {
                if (moneySymbol.ToLower() == money.Symbol.ToLower())
                    exist = true;
            }
            return exist;
        }

        public void SetMoney(Money money)
        {
            if (AlreadyExistTheMoneyName(money.Name))
                throw new ExceptionAlreadyExistTheMoneyName();
            if(AlreadyExistTheMoneySymbol(money.Symbol))
                throw new ExceptionAlreadyExistTheMoneySymbol();
            Monies.Add(money);
        }


    }
}