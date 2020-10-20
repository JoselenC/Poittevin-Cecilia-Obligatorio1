using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
   
    public class Repository
    {
        public List<Category> Categories = new List<Category>();

        public List<Expense> Expenses { get; set; }

        public List<Budget> Budgets { get; set; }

        public List<BudgetCategory> BudgetCategories { get; set; }

        public Repository()
        {
            Categories = new List<Category>();
            Expenses = new List<Expense>();
            Budgets = new List<Budget>();
            BudgetCategories = new List<BudgetCategory>();
        }             

        public Repository(List<Category> vCategories)
        {
            Expenses = new List<Expense>();
            Budgets = new List<Budget>();
            BudgetCategories = new List<BudgetCategory>();
            Categories = vCategories;
        }

        private bool AlreadyExistTheCategoryName(string categoryName)
        {
            bool exist = true ;
            foreach (Category category in Categories)
            {
                if (categoryName.ToLower() == category.Name.ToLower())
                   exist= false;
            }
            return exist;
        }

        private bool ExistKeyWord(List<string> pKeyWords, bool exist, string vKeyWord)
        {
            foreach (string pKeyWord in pKeyWords)
            {
                if (vKeyWord.ToLower() == pKeyWord.ToLower())
                    exist = false;
            }

            return exist;
        }

        private bool ExistKeyWordInAnotherCategory(List<string> pKeyWords, bool exist, Category category)
        {
            foreach (string vKeyWord in category.KeyWords)
            {
                exist = ExistKeyWord(pKeyWords, exist, vKeyWord);
            }

            return exist;
        }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(List<string> pKeyWords)
        {
            bool exist = true;
            foreach (Category category in Categories)
            {
                exist = ExistKeyWordInAnotherCategory(pKeyWords, exist, category);
            }
            return exist;
        }        

        public void AddCategory(Category category)
        {
            if (!AlreadyExistTheCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            if (!AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            this.Categories.Add(category);
        }

        public void AddBudget(Budget vBudget)
        {
            if (vBudget is null)
            {
                throw new ArgumentNullException();
            }
            Budgets.Add(vBudget);
        }

        public void AddBudgetCategory(BudgetCategory vCategory)
        {
            if (vCategory is null)
            {
                throw new ArgumentNullException();
            }
            BudgetCategories.Add(vCategory);
        }

        public void AddExpense(Expense expense)
        {
            if (expense.Category == null)
                throw new ExcepcionExpenseWithEmptyCategory();           
            Expenses.Add(expense);
        }       

        public void SetExpense(double amount, DateTime creationDate, string description, Category category)
        {
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description, Category = category };
            Expenses.Add(expense);
        }

        public void SetCategory(string vName,List<string> vKeyWords )
        {
            Category category = new Category { Name = vName, KeyWords = vKeyWords };
            Categories.Add(category);
        }

        public List<Category> GetCategories()
        {
            return Categories;
        }

        public List<Expense> GetExpenses()
        {
            return Expenses;
        }

        public List<Budget> GetBudgets()
        {
            return Budgets;
        }

    }
}