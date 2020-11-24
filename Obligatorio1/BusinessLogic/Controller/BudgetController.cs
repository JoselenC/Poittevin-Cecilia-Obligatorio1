using BusinessLogic.Domain;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BudgetController
    {
        private IManageRepository repository;

        public BudgetController(IManageRepository vRepository)
        {
            repository = vRepository;
        }           

        public List<Budget> GetBudgets()
        {
            return repository.GetBudgets();
        }

        public void SetBudget(Budget vBudget)
        {
            repository.SetBudget(vBudget);
        }      

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }

        public double GetTotalSpentByMonthAndCategory(string vMonth, Category vCategory)
        {
            Months mMonths = StringToMonthsEnum(vMonth);
            List<Expense> expenses = repository.GetExpenseByMonth(mMonths);
            double total = 0;
            foreach (Expense expense in expenses)
            {
                if (expense.IsSameCategory(vCategory))
                    total += expense.Amount*expense.Currency.Quotation;
            }
            return total;
        }

        public GenerateBudgetReport GetBudgetReport(string vMonth,Budget budget)
        {
           
            GenerateBudgetReport budgetsReport = new GenerateBudgetReport();
            budgetsReport.budgetsReportLines = new List<BudgetReportLine>();
            foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
            {
                BudgetReportLine budgetReport = new BudgetReportLine();
                Category category = budgetCategory.Category;
                budgetReport.PlanedAmount = budgetCategory.Amount;
                budgetReport.RealAmount = GetTotalSpentByMonthAndCategory(vMonth, category);
                budgetReport.DiffAmount = budgetReport.PlanedAmount - budgetReport.RealAmount;
                budgetsReport.TotalAmount += budgetReport.PlanedAmount;
                budgetsReport.RealAmount += budgetReport.RealAmount;
                budgetsReport.DiffAmount += budgetReport.DiffAmount;
                budgetReport.Category= budgetCategory.Category;
                budgetsReport.budgetsReportLines.Add(budgetReport);
            }

            return budgetsReport;
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
                List<Category> categories = repository.GetCategories();
                returnBudget = CreateBudget(year, categories, mMonth);
            }
            return returnBudget;
        }

        public Budget FindBudget(string month, int year)
        {
            return repository.FindBudget(month, year);
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
            List<Budget> budgets = repository.GetBudgets();
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
