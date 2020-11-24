using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using BusinessLogic.Domain;

namespace BusinessLogic
{
    public class ExpenseController
    {
        private IManageRepository repository;
       
        public ExpenseController(IManageRepository vRepository)
        {
            repository = vRepository;
        }

        public Expense FindExpense(Expense expense)
        {
            return repository.FindExpense(expense);
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            return repository.FindCategoryByDescription(vDescription);
        }

        public Expense DeleteExpense(Expense expenseToDelete)
        {
            Expense expense = FindExpense(expenseToDelete);
            repository.DeleteExpense(expense);
            return expense;
        }

        public List<Expense> GetExpenses()
        {
            return repository.GetExpenses();
        }

        private List<string> MonthsListIntToString(List<int> months)
        {
            List<string> monthsString = new List<string>();
            foreach (int month in months)
            {
                Months vMonth = (Months)month;
                string nameMonth = vMonth.ToString();
                monthsString.Add(nameMonth);
            }
            return monthsString;
        }

        public List<string> OrderedMonthsWithExpenses()
        {
            List<int> orderedMonthsInt = new List<int>();
            List<Expense> expenses = repository.GetExpenses();
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
            List<Expense> expenses = repository.GetExpenses();
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

        public GenerateExpenseReport GetExpenseReport(string month)
        {
            Months mMonth = StringToMonthsEnum(month);
            List<Expense> expenses= GetExpenseByMonth(mMonth);
            double totalAmount = 0;
            List<ExpenseReportLine> expensesReportLines = new List<ExpenseReportLine>();
            foreach (Expense expense in expenses)
            {
                ExpenseReportLine expenseReportLine= new ExpenseReportLine();               
                expenseReportLine.Amount = expense.Amount;
                expenseReportLine.Category = expense.Category;
                expenseReportLine.CreationDate = expense.CreationDate;
                expenseReportLine.Currency = expense.Currency;
                expenseReportLine.Description = expense.Description;
                expensesReportLines.Add(expenseReportLine);
                totalAmount+= expense.ConvertToPesos();

            }

            GenerateExpenseReport expenseReport = new GenerateExpenseReport() { ExpenseReportLine = expensesReportLines, TotalAmount = totalAmount };
            return expenseReport;
        }


        public Currency FindCurrencyByName(string CurrencyName)
        {
            return repository.FindCurrencyByName(CurrencyName);
        }

        public Category FindCategoryByName(string categoryName)
        {
            return repository.FindCategoryByName(categoryName);
        }

        public double AmountOfExpensesInAMonth(Months month)
        {
            double total = 0;
            List<Expense> expenses = repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.IsExpenseSameMonth(month))
                    total += expense.Amount;
            }
            return total;
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            repository.SetExpense(amount, creationDate, description, category, Currency);
        }

        public List<Category> GetCategories()
        {
            return repository.GetCategories();
        }

        public List<Currency> GetCurrencies()
        {
            return repository.GetCurrencies();
        }

        public void ExportExpenseReport(List<Expense> expenses, string fileName, string type)
        {
            IExportExpenseReport exportExpenseReport = new FactoryExportReport().GetExpenseReportInstance(type);
            exportExpenseReport.ExportReport(expenses, fileName);
        }
    }
    }
