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

        public MemoryRepository Repository { get; private set; }

        public LogicController(MemoryRepository repository)
        {
            Repository = repository;
        }

        private void EditBudgetCategory(Category oldCategory, Category newCategory, Budget budget)
        {
            foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
            {
                if (budgetCategory.Category.Equals(oldCategory))
                {
                    budgetCategory.Category = newCategory;
                }
            }
        }

        private void EditCategoryInAllBudgets(Category oldCategory, Category newCategory)
        {
            List<Budget> budgets = Repository.GetBudgets();
            foreach (Budget budget in budgets)
            {
                EditBudgetCategory(oldCategory, newCategory, budget);
            }
        }

        private void EditCategoryInAllExpenses(Category category, Category newCategory)
        {
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.Category.Equals(category))
                    expense.Category = newCategory;
            }
        }

        public void EditCategory(Category oldCategory, string newName, List<string> newKeywords)
        {
            Repository.DeleteCategory(oldCategory);
            Category newCategory = SetCategory(newName, newKeywords);
            EditCategoryInAllExpenses(oldCategory, newCategory);
            EditCategoryInAllBudgets(oldCategory, newCategory);
        }


        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }

        public Budget FindBudget(string month, int year)
        {
            return Repository.FindBudget(month, year);
        }

        private Budget CreateBudget(int year, List<Category> categories, Months month)
        {
            Budget budget = new Budget(month, categories) { Year = year, TotalAmount = 0 };
            return budget;
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
                returnBudget = CreateBudget(year, categories, mMonth);
            }
            return returnBudget;
        }

        public List<Expense> GetExpenses()
        {
            return Repository.GetExpenses();
        }

        public List<Budget> GetBudgets()
        {
            return Repository.GetBudgets();
        }

        private bool IsExpenseSameMonth(Months month, Expense vExpense)
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
                if (IsSameCategory(vCategory,expense))
                    total += expense.Amount;
            }
            return total;
        }

        private void AddCategoryInAllBudgets(Category category)
        {
            foreach (Budget budget in Repository.GetBudgets())
            {
                budget.AddBudgetCategory(category);
            }
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            
            Category category = Repository.SetCategory(vName, vKeyWords);
            AddCategoryInAllBudgets(category);
            return category;
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category)
        {
            Repository.SetExpense(amount, creationDate, description, category);
        }   

        public Category FindCategoryByDescription(string vDescription)
        {
            return Repository.FindCategoryByDescription(vDescription);
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

        private List<string> MonthsEnumToStrings(List<Months> months)
        {
            List<string> monthStrings = new List<string>();
            foreach (Months month in months)
            {
                monthStrings.Add(month.ToString());
            }
            return monthStrings;
        }

        public List<string> OrderedMonthsWithBudget()
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

        public Category FindCategoryByName(string categoryName)
        {
            return Repository.FindCategoryByName(categoryName);      
        }

        public Expense FindExpense(Expense expense)
        {
           return  Repository.FindExpense(expense);
        }

        public void AlreadyExistKeyWordInAnoterCategory(string pKeyWord)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (Category category in categories)
            {
                if (category.ExistThisKey(pKeyWord))
                    throw new ExcepcionInvalidRepeatedKeyWordsInAnotherCategory();
            }           
        }     

        public string[] GetAllMonthsString()
        {
            return Enum.GetNames(typeof(Months)).ToArray();
        }

        public void SetBudget(Budget vBudget)
        {
            Repository.AddBudget(vBudget);
        }
                
        public Expense DeleteExpense(Expense expenseToDelete)
        {
            Expense expense = FindExpense(expenseToDelete);
            Repository.DeleteExpense(expense);
            return expense;
        }

        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }       

       

        
       
    }

}