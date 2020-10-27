using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
   
    public class Repository
    {
        private List<Category> Categories;

        private List<Expense> Expenses;

        private List<Budget> Budgets;

        private List<BudgetCategory> BudgetCategories;

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


        private bool AlreadyExistTheKeyWordsInAnoterCategory(KeyWord pkeyWords)
        {            
            foreach (Category category in Categories)
            {
                if (category.ExistKeyWordInAnotherCategory(pkeyWords))
                    return true;
            }
            return false;
        }       

        public void AddCategory(Category category)
        {
            if (!AlreadyExistTheCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            if (AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            Categories.Add(category);
        }

        public void AddBudget(Budget vBudget)
        {
            if (vBudget is null)
            {
                throw new ArgumentNullException();
            }
            Budgets.Add(vBudget);
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

        public void DeleteExpense(Expense expense)
        {
            Expenses.Remove(expense);
        }

        public void DeleteCategory(Category category)
        {
            Categories.Remove(category);
        }

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }


        public Budget FindBudget(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            Budget budget = Budgets.Find(e => e.IsSameCreationDate(mMonth, year));
            if (budget==null)
                     throw new NoFindBudget();
            return budget;
        }      

        private Category FindCategoryByDescription(string[] descriptionArray)
        {
            Category category = null;
            foreach (Category vCategory in Categories)
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
            Category category= Categories.Find(e => e.IsSameCategoryName(categoryName));      
            if(category==null)
            throw new NoFindCategoryByName();
            return category;
        }

        public Expense FindExpense(Expense vExpense)
        {
            Expense expense = Expenses.Find(e => e.Equals(vExpense));
            if (expense == null)
            throw new NoFindEqualsExpense();
            return expense;
        }

    }
}