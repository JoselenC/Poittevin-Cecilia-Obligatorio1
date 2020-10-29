using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BudgetController
    {
        public MemoryRepository Repository { get; private set; }

        public BudgetController(MemoryRepository repository)
        {
            Repository = repository;
        }
       
        public List<Expense> GetExpenseByMonth(Months month)
        {
            List<Expense> expensesByMonth = new List<Expense>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense vExpense in expenses)
            {
                if (vExpense.IsExpenseSameMonth(month))
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }        

        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }

        public double AmountOfExpensesInAMonth(Months month)
        {
            double total = 0;
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.IsExpenseSameMonth(month))
                    total += expense.Amount;
            }
            return total;
        }

        public List<Budget> GetBudgets()
        {
            return Repository.GetBudgets();
        }

        public void SetBudget(Budget vBudget)
        {
            Repository.AddBudget(vBudget);
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

        private static bool IsSameCategory(Category vCategory, Expense expense)
        {
            return expense.Category == vCategory;
        }

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
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

        public Budget FindBudget(string month, int year)
        {
            return Repository.FindBudget(month, year);
        }

        public string[] GetAllMonthsString()
        {
            return Enum.GetNames(typeof(Months)).ToArray();
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

    }
}
