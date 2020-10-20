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
            returnBudget = CreateBudget(year, categories, monthIndex, returnBudget);
            return returnBudget;

        }

        private Budget CreateBudget(int year, List<Category> categories, int monthIndex, Budget returnBudget)
        {
            if (returnBudget is null)
            {
                returnBudget = new Budget(monthIndex, categories) { Year = year, TotalAmount = 0 };
                AddBudget(returnBudget);
            }
            return returnBudget;
        }

        public List<Expense> GetExpenseByMonth(string month)
        {

            int monthInt = StringToIntMonth(month);
            List<Expense> expensesByMonth = new List<Expense>();
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense vExpense in expenses)
            {
                AddExpenseSameMonth(monthInt, expensesByMonth, vExpense);
            }
            return expensesByMonth;
        }

        private static void AddExpenseSameMonth(int monthInt, List<Expense> expensesByMonth, Expense vExpense)
        {
            if (vExpense.CreationDate.Month == monthInt)
                expensesByMonth.Add(vExpense);
        }

        public double GetTotalSpentByMonthAndCategory(string vMonth, Category vCategory)
        {
            List<Expense> expenses = GetExpenseByMonth(vMonth);
            double total = 0;
            foreach (Expense expense in expenses)
            {
                total = AmountOfExpenseWithCategory(vCategory, total, expense);
            }
            return total;
        }

        private static double AmountOfExpenseWithCategory(Category vCategory, double total, Expense expense)
        {
            if (expense.Category == vCategory)
                total += expense.Amount;
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
      

       
        public Budget FindBudget(int month, int year)
        {
            List<Budget> budgets = Repository.GetBudgets();
            foreach (var budget in budgets)
            {
                if (SameCreationDate(budget,month,year))
                    return budget;
            }
            return null;
        }

        private bool SameCreationDate(Budget budget,int month,int year)
        {
            if (budget.Month == month && budget.Year == year)
                return true;
            return false;
        }

        public Category AsignCategoryByDescriptionExpense(string vDescription)
        {
            Category category = null;
            string[] descriptionArray = vDescription.Split(' ');
            bool exist = false;
            int cont = 0;
            List<Category> categories = Repository.GetCategories();
            exist = FindCategoryByDescription(ref category, descriptionArray, exist, ref cont, categories);
            if (cont == 1)
                return category;
            return null;
        }

        private bool FindCategoryByDescription(ref Category category, string[] descriptionArray, bool exist, ref int cont, List<Category> categories)
        {
            foreach (Category vCategory in categories)
            {
                exist = ExistCategoryInDescriptionExpense(descriptionArray, vCategory);
                AsignCategory(ref category, exist, ref cont, vCategory);
            }
            return exist;
        }

        private void AsignCategory(ref Category category, bool exist, ref int cont, Category vCategory)
        {
            if (exist)
            {
                category = vCategory;
                cont = cont + 1;
            }
        }

        private bool ExistCategoryInDescriptionExpense(string[] descriptionArray,Category vCategory)
        {
            bool exist = false;
            foreach (string description in descriptionArray)
            {
                exist = vCategory.KeyWords.Contains(description);
                if (exist == true)
                    return true;
            }         
            return exist;
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
                AddMonthExpense(orderedMonthsInt, expense);
            }
            orderedMonthsInt.Sort();
            List<string> orderedMonthsString = MonthsListStringToInt(orderedMonthsInt);
            return orderedMonthsString;
        }

        private void AddMonthExpense(List<int> orderedMonthsInt, Expense expense)
        {
            if (!orderedMonthsInt.Contains(expense.CreationDate.Month))
                orderedMonthsInt.Add(expense.CreationDate.Month);
        }

        public double AmountOfExpensesInAMonth(string month)
        {
            int monthInt = StringToIntMonth(month);
            double total = 0;
            List<Expense> expenses = Repository.GetExpenses();
            foreach (Expense expense in expenses)
            {
                total = AmountOfExpenseInAMonth(monthInt, total, expense);
            }
            return total;
        }

        private static double AmountOfExpenseInAMonth(int monthInt, double total, Expense expense)
        {
            if (expense.CreationDate.Month == monthInt)
                total += expense.Amount;
            return total;
        }

        public Category FindCategoryByName(string categoryName)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (var category in categories)
            {
                if (SameCategoryName(category, categoryName))
                    return category;
            }
            return null;
        }

        private bool SameCategoryName(Category category, string categoryName)
        {
            if (category.Name == categoryName)
                return true;
            return false;
        }

        public Expense FindExpense(string expenseDescription)
        {
            List<Expense> expenses = Repository.GetExpenses();
            foreach (var expense in expenses)
            {
                if (SameDescriptionExpense(expense,expenseDescription))
                    return expense;
            }
            return null;
        }

        private bool SameDescriptionExpense(Expense expense,string expenseDescription)
        {
            if (expense.Description == expenseDescription)
                return true;
            return false;
        }

        public bool AlreadyExistThisKeyWordInAnoterCategory(string pKeyWord)
        {
            bool exist = false;
            List<Category> categories = Repository.GetCategories();
            foreach (Category category in categories)
            {
                exist = ExistKeyWord(pKeyWord, exist, category);
            }
            return exist;
        }

        private bool ExistKeyWord(string pKeyWord, bool exist, Category category)
        {
            foreach (string vKeyWord in category.KeyWords)
            {
                if (pKeyWord.ToLower() == vKeyWord.ToLower())
                    exist = true;
            }
            return exist;
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

        public Expense DeleteExpense(string description)
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