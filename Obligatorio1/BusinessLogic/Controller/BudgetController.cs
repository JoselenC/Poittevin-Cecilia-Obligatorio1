using BusinessLogic.Domain;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BudgetController
    {
        private readonly ManagerRepository repository;

        public BudgetController(ManagerRepository vRepository)
        {
            repository = vRepository;
        }

        public List<Budget> GetBudgets()
        {
            return repository.Budgets.Get();
        }

        public void SetBudget(Budget vBudget)
        {
            repository.Budgets.Add(vBudget);
        }

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        } 
     
        public GenerateBudgetReport GetBudgetReport(string vMonth, int year)
        {
            ExpenseController expenseController = new ExpenseController(repository);
            double totalPlanedAmount = 0;
            double totalRealAmount = 0;
            double totalDiffAmount = 0;
            double realAmount = 0;
            Budget budget = FindBudget(vMonth, year);

            GenerateBudgetReport budgetReport = new GenerateBudgetReport
            {
                budgetsReportLines = new List<BudgetReportLine>()
            };
            foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
            {
                BudgetReportLine budgetReportLine = new BudgetReportLine();
                budgetReportLine.PlanedAmount = budgetCategory.Amount;
                Category category = budgetCategory.Category;
                try
                {                  
                    budgetReportLine.RealAmount = expenseController.GetTotalSpentByDateAndCategory(vMonth, category, year);
                    realAmount = expenseController.GetTotalSpentByDateAndCategory(vMonth, category, year);
                }
                catch (NoFindExpenseByDate)
                {
                    budgetReportLine.RealAmount = 0;
                    realAmount = 0;
                }
                double planeedAmount = budgetCategory.Amount;               
                double diffAmount = planeedAmount - realAmount;
                totalPlanedAmount = planeedAmount;
                totalRealAmount = realAmount;
                totalDiffAmount = diffAmount;
                budgetReportLine.DiffAmount = diffAmount;
                budgetReport.TotalAmount += planeedAmount;
                budgetReport.RealAmount += realAmount;
                budgetReport.DiffAmount += diffAmount;
                budgetReportLine.Category= budgetCategory.Category;
                budgetReport.budgetsReportLines.Add(budgetReportLine);
            }
            return budgetReport;
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
                List<Category> categories = repository.Categories.Get();
                returnBudget = CreateBudget(year, categories, mMonth);
            }
            return returnBudget;
        }

        public Budget FindBudget(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            try
            {
                return repository.Budgets.Find(e => e.IsSameCreationDate(mMonth, year));
            }
            catch (ValueNotFound)
            {
                throw new NoFindBudget();
            }
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
            List<Budget> budgets = repository.Budgets.Get();
            foreach (Budget budget in budgets)
            {
                if (!monthsWithBudget.Contains(budget.Month))
                    monthsWithBudget.Add(budget.Month);
            }
            monthsWithBudget.Sort();
            List<string> orderedMonthsString = MonthsEnumToStrings(monthsWithBudget);
            return orderedMonthsString;
        }

        public void AddCategoryInAllBudgets(Category category)
        {
            foreach (Budget budget in repository.Budgets.Get())
            {
                budget.AddBudgetCategory(category);
                repository.Budgets.Add(budget);
            }           
        }


    }
}
