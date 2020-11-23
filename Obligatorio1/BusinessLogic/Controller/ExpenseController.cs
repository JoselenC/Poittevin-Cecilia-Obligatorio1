using BusinessLogic.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class ExpenseController
    {
        public IManageRepository Repository { get; private set; }
        public IExportExpenseReport Export { get; set; }
        public ExpenseController(IManageRepository repository)
        {
            Repository = repository;
        }

        public Expense FindExpense(Expense expense)
        {
            return Repository.FindExpense(expense);
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            return Repository.FindCategoryByDescription(vDescription);
        }

        public Expense DeleteExpense(Expense expenseToDelete)
        {
            Expense expense = FindExpense(expenseToDelete);
            Repository.DeleteExpense(expense);
            return expense;
        }

        public List<Expense> GetExpenses()
        {
            return Repository.GetExpenses();
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

        private Months StringToMonthsEnum(string month)
        {
            return (Months)Enum.Parse(typeof(Months), month);
        }

        public List<Expense> GetExpenseByMonth(string month)
        {
            Months mMonth = StringToMonthsEnum(month);
            return GetExpenseByMonth(mMonth);
        }

        public Currency FindCurrencyByName(string CurrencyName)
        {
            return Repository.FindCurrencyByName(CurrencyName);
        }

        public Category FindCategoryByName(string categoryName)
        {
            return Repository.FindCategoryByName(categoryName);
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

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            Repository.SetExpense(amount, creationDate, description, category, Currency);
        }

        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }

        public List<Currency> GetCurrencies()
        {
            return Repository.GetCurrencies();
        }

        public void ExportExpenseReport(List<Expense> expenses, string fileName, int index)
        {
            if (index == 1)
                Export = new ExpenseReportTXT();
            else
                Export = new ExpenseReportCSV();

            Export.ExportReport(expenses, fileName);
        }
    }
    }
