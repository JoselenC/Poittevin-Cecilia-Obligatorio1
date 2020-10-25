using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LogicController
    {

        public Repository Repository { get; private set; }

        public LogicController(Repository repository)
        {
            Repository = repository;
        }

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }


        private bool IsSameCreationDate(Budget budget, Months month, int year)
        {
            if (budget.Month == month && budget.Year == year)
                return true;
            return false;
        }

        public Budget FindBudget(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            List<Budget> budgets = Repository.GetBudgets();
            foreach (var budget in budgets)
            {
                if (IsSameCreationDate(budget, mMonth, year))
                    return budget;
            }
            throw new NoFindBudget();
        }

        private List<Category> BudgetCategories(List<Category> repoCategories, List<BudgetCategory> budgetCategories)
        {
            bool alreadyExist;
            List<Category> newBudgetCategories = new List<Category>();
            foreach (var repoCategory in repoCategories)
            {
                alreadyExist = false;
                foreach (var category in budgetCategories)
                {
                    if (!alreadyExist)
                    {
                        if (repoCategory == category.Category)
                            alreadyExist = true;
                    }
                }
                if (!alreadyExist)
                    newBudgetCategories.Add(repoCategory);
            }
            return newBudgetCategories;
        }
        private Budget CreateBudget(int year, List<Category> categories, Months month, Budget returnBudget)
        {
            if (returnBudget is null)
            {
                returnBudget = new Budget(month, categories) { Year = year, TotalAmount = 0 };               
               
            }
            else
            {
                Budget oldBudget = returnBudget;
                Repository.GetBudgets().Remove(returnBudget);
                List<Category> budgetCategories = BudgetCategories(categories, oldBudget.BudgetCategories);
                returnBudget = new Budget(month, budgetCategories) { Year = year, TotalAmount = 0 };
                foreach (var category in oldBudget.BudgetCategories)
                {
                    returnBudget.BudgetCategories.Add(category);
                }

                Repository.GetBudgets().Add(returnBudget);
            }
            
            return returnBudget;
        }


        public Budget BudgetGetOrCreate(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            Budget returnBudget;
            List<Category> categories = Repository.GetCategories();
            try
            {               
                returnBudget = FindBudget(month, year);                
            }
            catch (NoFindBudget)
            {
                returnBudget=null;
            }
            returnBudget = CreateBudget(year, categories, mMonth, returnBudget);
            return returnBudget;

        }

        public List<Expense> GetExpenses()
        {
            return Repository.GetExpenses();
        }

        private static bool IsExpenseSameMonth(Months month, Expense vExpense)
        {
            int expected = vExpense.CreationDate.Month;
            int actual = (int)month;
            return expected == actual;
                
        }

        public List<Expense> GetExpenseByMonth(Months month)
        {
            List<Expense> expensesByMonth = new List<Expense>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense vExpense in expenses)
            {
                if (IsExpenseSameMonth(month, vExpense))
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }

        public List<Expense> GetExpenseByMonth(string month)
        {
            Months mMonth = StringToMonthsEnum(month);
            return GetExpenseByMonth(mMonth);
        }

        private static bool IsSameCategory(Category vCategory, Expense expense)
        {
            return expense.Category == vCategory;

        }

        public double GetTotalSpentByMonthAndCategory(string vMonth, Category vCategory)
        {
            Months mMonths = StringToMonthsEnum(vMonth);
            List<Expense> expenses = GetExpenseByMonth(mMonths);
            double total = 0;
            foreach (Expense expense in expenses)
            {
                if (IsSameCategory(vCategory, expense))
                    total += expense.Amount;
            }
            return total;
        }
      
        public void SetCategory(string vName, List<string> vKeyWords)
        {
            Repository.SetCategory(vName, vKeyWords);
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category)
        {
            Repository.SetExpense(amount, creationDate, description, category);
        }        

        private Category FindCategoryByDescription(string[] descriptionArray)
        {
            List<Category> categories = Repository.GetCategories();
            bool categoryFound = false;
            Category category = null;
            foreach (Category vCategory in categories)
            {
                if (IsDescriptionOfCategory(descriptionArray, vCategory))
                {
                    if(categoryFound)
                        throw new NoAsignCategoryByDescriptionExpense();
                    categoryFound = true;
                    category = vCategory;
                }
            }
            if(!categoryFound)
                throw new NoAsignCategoryByDescriptionExpense();
            return category;
        }


        public Category FindCategoryByDescription(string vDescription)
        {
            string[] descriptionArray = vDescription.Split(' ');

            return FindCategoryByDescription(descriptionArray);
        }

        private bool IsDescriptionOfCategory(string[] descriptionArray,Category vCategory)
        {
            bool exist = false;
            foreach (string description in descriptionArray)
            {
                exist = vCategory.KeyWords.KeywordContainsAPartOfDescription(description);
                if (exist == true)
                    return true;
            }         
            return exist;
        }

        private List<string> MonthsListIntToString(List<int> months)
        {
            List<string> monthsString = new List<string>();
            foreach (int month in months)
            {
                Months vMonth = (Months)month;
                string nombreMes = vMonth.ToString();
                monthsString.Add(nombreMes);
            }
            return monthsString;
        }


        public List<string> OrderedMonthsWithExpenses()
        {
            List<int> orderedMonthsInt = new List<int>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (!orderedMonthsInt.Contains(expense.CreationDate.Month))
                    orderedMonthsInt.Add(expense.CreationDate.Month);
            }
            orderedMonthsInt.Sort();
            List<string> orderedMonthsString = MonthsListIntToString(orderedMonthsInt);
            return orderedMonthsString;
        }


        public List<string> OrderedMonthsInWhichThereAreBudget()
        {
            List<Months> monthsWithBudget = new List<Months>();
            List<Budget> budgets = Repository.GetBudgets();
            foreach (Budget budget in budgets)
            {
                if (!monthsWithBudget.Contains(budget.Month))
                    monthsWithBudget.Add(budget.Month);
            }
            monthsWithBudget.Sort();
            List<string> orderedMonthsString = MonthsEnumToStrings(monthsWithBudget);
            return orderedMonthsString;
        }

        public double AmountOfExpensesInAMonth(Months month)
        {
            double total = 0;
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if(IsExpenseSameMonth(month, expense))
                    total += expense.Amount;
            }
            return total;
        }

        private bool IsSameCategoryName(Category category, string categoryName)
        {
            return category.Name == categoryName;
        }

        public Category FindCategoryByName(string categoryName)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (var category in categories)
            {
                if (IsSameCategoryName(category, categoryName))
                    return category;
            }
            throw new NoFindCategoryByName();
        }


        public Expense FindExpense(Expense expense)
        {
            List<Expense> expenses = Repository.GetExpenses();
          
                foreach (var expense2 in expenses)
                {
                    if (expense.Equals(expense2))
                        return expense;
                }
            
            return null;
        }

        private bool KeyWordExists(string pKeyWord, ref bool exist, Category category)
        {
            return category.KeyWords.ExistThisKey(pKeyWord, ref exist, category);
        }

        public bool AlreadyExistKeyWordInAnoterCategory(string pKeyWord)
        {
            bool exist = false;
            List<Category> categories = Repository.GetCategories();
            foreach (Category category in categories)
            {
                exist = KeyWordExists(pKeyWord, ref exist, category);
            }
            return exist;
        }

        private List<string> MonthsEnumToStrings(List<Months> months)
        {
            List<string> monthStrings = new List<string>();
            foreach (Months month in months)
            {
                monthStrings.Add(month.ToString());
            }
            return monthStrings;
        }

        public string[] GetAllMonthsString()
        {
            return Enum.GetNames(typeof(Months)).ToArray();
        }

        public string[] GetAllCategoryStrings()
        {
            List<string> categoryNames = new List<string>();
            List<Category> categories = GetCategories();
            foreach (var category in categories)
            {
                categoryNames.Add(category.ToString());
            }
            return categoryNames.ToArray();
        }

        public void AddBudget(Budget vBudget)
        {
            Repository.AddBudget(vBudget);
        }

        public void AddBudgetCategory(BudgetCategory vCategory)
        {
            Repository.AddBudgetCategory(vCategory);
        }

        public void AddCategory(Category category)
        {
            Repository.AddCategory(category);
        }

        public void AddExpense(Expense expense)
        {
            Repository.AddExpense(expense);
        }        
        

        public Expense DeleteExpense(Expense expenseToDelete)
        {
            Expense expense = FindExpense(expenseToDelete);
            Repository.GetExpenses().Remove(expense);
            return expense;
        }
        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }

        
        public void EditCategoryExpense(Category category, string name, List<string> keywords)
        {
            KeyWord pKeyWord = new KeyWord(keywords);
            Category newCategory = new Category { Name = name, KeyWords = pKeyWord };
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.Category.Equals(category))
                    expense.Category = newCategory;
            }
        }
        public void EditCategoryBudget(Category category, string name, List<string> keywords)
        {
            KeyWord pKeyWord = new KeyWord(keywords);
            Category newCategory = new Category { Name = name, KeyWords = pKeyWord };
            List<Budget> budgets = Repository.GetBudgets();
            foreach (Budget budget in budgets)
            {
                foreach(BudgetCategory budgetCategory in budget.BudgetCategories)
                {
                    if(budgetCategory.Category.Equals(category)){
                        budgetCategory.Category = newCategory;
                    }
                }
            }
        }

    }

}