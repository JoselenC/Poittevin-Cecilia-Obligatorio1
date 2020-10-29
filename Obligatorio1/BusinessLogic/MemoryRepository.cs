using System;
using System.Collections.Generic;

namespace BusinessLogic
{
   
    public class MemoryRepository
    {
        private Repository<Category> Categories;

        private Repository<Expense> Expenses;

        private Repository<Budget> Budgets;

        private Repository<BudgetCategory> BudgetCategories;

        public MemoryRepository()
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            BudgetCategories = new Repository<BudgetCategory>();
        }     

        public MemoryRepository(List<Category> vCategories)
        {
            Categories = new Repository<Category>();
            Expenses = new Repository<Expense>();
            Budgets = new Repository<Budget>();
            BudgetCategories = new Repository<BudgetCategory>();
            Categories.Set(vCategories);
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
                if (category.ExistKeyWordInAnotherCategory(pkeyWords))
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

        public void SetExpense(double amount, DateTime creationDate, string description, Category category)
        {
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description, Category = category };
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

    }
}