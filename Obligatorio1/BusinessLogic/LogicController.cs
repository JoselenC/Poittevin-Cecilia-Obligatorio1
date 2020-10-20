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

        public double GetTotalSpentByMonthAndCategory(string vMonth, Category vCategory)
        {
            List<Expense> expenses = GetExpenseByMonth(vMonth);
            double total = 0;
            foreach (Expense expense in expenses)
            {
                if (expense.Category == vCategory)
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
        private int StringToIntMonth(string month)
        {
            int monthInBaseCero = (int)Enum.Parse(typeof(Months), month);
            int monthInBaseOne = monthInBaseCero + 1;
            return monthInBaseOne;
        }

        public Budget BudgetGetOrCreate(string month, int year)
        {
                List<Category> categories = Repository.GetCategories();
                int monthIndex = StringToIntMonth(month);
                Budget returnBudget = FindBudget(monthIndex, year);
                if (returnBudget is null)
                {
                    returnBudget = new Budget(monthIndex, categories) { Year = year, TotalAmount = 0 };
                    AddBudget(returnBudget);
                }
                return returnBudget;
            
        }

       
        public Budget FindBudget(int month, int year)
        {
            List<Budget> budgets = Repository.GetBudgets();
            foreach (var budget in budgets)
            {
                if (budget.Month == month && budget.Year == year)
                    return budget;
            }
            return null;
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            Category category = null;
            string[] descriptionArray = vDescription.Split(' ');
            bool exist = false;
            int cont = 0;
            List<Category> categories = Repository.GetCategories();
            foreach (Category vCategory in categories)
            {
                exist = false;
                foreach (String description in descriptionArray)
                {
                    exist = vCategory.KeyWords.Contains(description);
                }
                if (exist)
                {
                    category = vCategory;
                    cont = cont + 1;
                }
            }
            if (cont == 1)
                return category;
            else
                return null;
        }

        private List<string> MonthsListStringToInt(List<int> months)
        {
            List<string> monthsString = new List<string>();
            foreach (int month in months)
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(month);
                monthsString.Add(nombreMes);
            }
            return monthsString;
        }
        public List<string> OrderedMonthsInWhichThereAreExpenses()
        {
            List<int> orderedMonthsInt = new List<int>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (!orderedMonthsInt.Contains(expense.CreationDate.Month))
                    orderedMonthsInt.Add(expense.CreationDate.Month);
            }
            orderedMonthsInt.Sort();
            List<string> orderedMonthsString = MonthsListStringToInt(orderedMonthsInt);
            return orderedMonthsString;
        }
       
        public double AmountOfExpensesInAMonth(string month)
        {
            int monthInt = StringToIntMonth(month);
            double total = 0;
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.CreationDate.Month == monthInt)
                    total += expense.Amount;
            }
            return total;
        }

        public List<Expense> GetExpenseByMonth(string month)
        {

            int monthInt = StringToIntMonth(month);
            List<Expense> expensesByMonth = new List<Expense>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense vExpense in expenses)
            {
                if (vExpense.CreationDate.Month == monthInt)
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }
        public Category FindCategoryByName(string categoryName)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (var category in categories)
            {
                if (category.Name == categoryName)
                    return category;
            }
            return null;
        }
        public Expense FindExpense(string expenseDescription)
        {
            List<Expense> expenses = Repository.GetExpenses();
            foreach (var expense in expenses)
            {
                if (expense.Description == expenseDescription)
                    return expense;
            }
            return null;
        }
        public bool AlreadyExistThisKeyWordInAnoterCategory(string pKeyWord)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (Category category in categories)
            {
                foreach (string vKeyWord in category.KeyWords)
                {
                    if (pKeyWord.ToLower() == vKeyWord.ToLower())
                        return true;
                }
            }
            return false;
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
        public string[] GetAllCategoryStrings()
        {
            return Repository.GetAllCategoryStrings();
        }

        public Expense DeleteAndGetExpense(string description)
        {
            Expense expense = FindExpense(description);
            Repository.GetExpenses().Remove(expense);
            return expense;
        }
        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }

        public string[] GetAllMonthsString()
        {
            return Repository.GetAllMonthsString();
        }
        public List<Expense> GetExpenses()
        {
            return Repository.GetExpenses();
        }

    }

}