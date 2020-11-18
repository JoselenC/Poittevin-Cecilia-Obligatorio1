using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BudgetController
    {
        public IManageRepository Repository { get; private set; }

        public BudgetController(IManageRepository repository)
        {
            Repository = repository;
        }           

        public List<Budget> GetBudgets()
        {
            return Repository.GetBudgets();
        }

        public void SetBudget(Budget vBudget)
        {
            Repository.SetBudget(vBudget);
        }      

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }

        public double GetTotalSpentByMonthAndCategory(string vMonth, Category vCategory)
        {
            Months mMonths = StringToMonthsEnum(vMonth);
            List<Expense> expenses = Repository.GetExpenseByMonth(mMonths);
            double total = 0;
            foreach (Expense expense in expenses)
            {
                if (expense.IsSameCategory(vCategory))
                    total += expense.Amount*expense.Currency.Quotation;
            }
            return total;
        }

        private Budget CreateBudget(int year, List<Category> categories, Months month)
        {
            if (categories.Count==0)
                throw new ExceptionBudgetWithEmptyCategory();
            Budget budget = new Budget(month, categories) { Year = year, TotalAmount = 0 };
            return budget;
        }

        public Budget BudgetGetOrCreate(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            Budget returnBudget;
            try
            {
                returnBudget = FindBudget(month, year);
            }
            catch (NoFindBudget)
            {
                List<Category> categories = Repository.GetCategories();
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
