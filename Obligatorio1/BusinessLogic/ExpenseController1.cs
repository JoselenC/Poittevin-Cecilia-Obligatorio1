using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ExpenseController
    {
        public MemoryRepository Repository { get; private set; }

        public ExpenseController(MemoryRepository repository)
        {
            Repository = repository;
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

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
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

        public List<Budget> GetBudgets()
        {
            return Repository.GetBudgets();
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

        public void SetBudget(Budget vBudget)
        {
            Repository.AddBudget(vBudget);
        }

        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }

        public string[] GetAllMonthsString()
        {
            return Enum.GetNames(typeof(Months)).ToArray();
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
    }
}
