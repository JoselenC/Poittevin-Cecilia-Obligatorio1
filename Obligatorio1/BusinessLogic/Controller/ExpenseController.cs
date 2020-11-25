using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using BusinessLogic.Domain;

namespace BusinessLogic
{
    public class ExpenseController
    {
        private ManagerRepository repository;
       
        public ExpenseController(ManagerRepository vRepository)
        {
            repository = vRepository;
        }

        public Expense FindExpense(Expense expense)
        {
            try
            {
                return repository.Expenses.Find(e => e.Equals(expense));
            }
            catch (ValueNotFound)
            {
                throw new NoFindEqualsExpense();
            }
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            CategoryController categoryController = new CategoryController(repository);
            return categoryController.FindCategoryByDescription(vDescription);
        }

        public Expense DeleteExpense(Expense expenseToDelete)
        {
            Expense expense = FindExpense(expenseToDelete);
            repository.Expenses.Delete(expense);
            return expense;
        }

        public List<Expense> GetExpenses()
        {
            return repository.Expenses.Get();
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
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (!orderedMonthsInt.Contains(expense.CreationDate.Month))
                    orderedMonthsInt.Add(expense.CreationDate.Month);
            }
            orderedMonthsInt.Sort();
            List<string> orderedMonthsString = MonthsListIntToString(orderedMonthsInt);
            return orderedMonthsString;
        }

        public List<int> OrderedYearsWithExpenses()
        {
            List<int> orderedYEarsInt = new List<int>();
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (!orderedYEarsInt.Contains(expense.CreationDate.Year))
                    orderedYEarsInt.Add(expense.CreationDate.Year);
            }
            orderedYEarsInt.Sort();
            return orderedYEarsInt;
        }

        public List<Expense> GetExpenseByMonth(Months month)
        {
            List<Expense> expensesByMonth = new List<Expense>();
            foreach (Expense vExpense in GetExpenses())
            {
                if (vExpense.IsExpenseSameMonth(month))
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }

        public List<Expense> GetExpenseByDate(string month, int year)
        {
            Months mMonth = StringToMonthsEnum(month);
            List<Expense> expensesByMonth = new List<Expense>();
            List<Expense> expenses = GetExpenses();
            foreach (Expense vExpense in expenses)
            {
                if (vExpense.IsExpenseSameDate(mMonth, year))
                    expensesByMonth.Add(vExpense);
            }
            if (expensesByMonth.Count == 0)
                throw new NoFindExpenseByDate();
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

        public GenerateExpenseReport GetExpenseReport(string month,int year)
        {
            List<Expense> expenses= GetExpenseByDate(month,year);
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
            CurrencyController currencyController = new CurrencyController(repository);
            return currencyController.FindCurrencyByName(CurrencyName);
        }

        public Category FindCategoryByName(string categoryName)
        {
            return repository.FindCategoryByName(categoryName);
        }

        public double AmountOfExpensesInAMonth(Months month)
        {
            double total = 0;
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.IsExpenseSameMonth(month))
                    total += expense.Amount;
            }
            return total;
        }

        private void AddExpense(Expense expense)
        {
            if (expense.Category == null)
                throw new ExcepcionExpenseWithEmptyCategory();
            repository.Expenses.Add(expense);
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            Expense expense = new Expense
            {
                Amount = amount,
                CreationDate = creationDate,
                Description = description,
                Category = category,
                Currency = Currency
            };
            AddExpense(expense);
        }

        // TODO: revisar si podemos llamar directamente al GetCategories de el CategoryController
        public List<Category> GetCategories()
        {
            return repository.Categories.Get();
        }

        // TODO: revisar si podemos llamar directamente al GetCurrencies de el CurrencyController
        public List<Currency> GetCurrencies()
        {
            return repository.Currencies.Get();
        }

        public void ExportExpenseReport(List<Expense> expenses, string fileName, string type)
        {
            IExportExpenseReport exportExpenseReport = new FactoryExportReport().GetExpenseReportInstance(type);
            exportExpenseReport.ExportReport(expenses, fileName);
        }
    }
    }
