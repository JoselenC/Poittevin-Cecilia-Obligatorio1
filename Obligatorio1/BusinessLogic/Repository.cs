using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
   
    public class Repository
    {
        public List<Category> Categories = new List<Category>();

        public List<Expense> Expenses { get; set; }

        public List<Budget> Budgets { get; set; }

        public List<BudgetCategory> BudgetCategories { get; set; }

        public Repository()
        {
            Categories = new List<Category>();
            Expenses = new List<Expense>();
            Budgets = new List<Budget>();
            BudgetCategories = new List<BudgetCategory>();
        }
             

        public Repository(List<Category> vCategories)
        {
            Expenses = new List<Expense>();
            Budgets = new List<Budget>();
            BudgetCategories = new List<BudgetCategory>();
            Categories = vCategories;
        }



        public Category FindCategoryByDescription(string vDescription)
        {
            Category category = null;
            string[] descriptionArray = vDescription.Split(' ');
            bool exist = false;
            int cont = 0;
            foreach (Category vCategory in Categories)
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
            foreach (Expense expense in Expenses)
            {
                if (!orderedMonthsInt.Contains(expense.CreationDate.Month))
                    orderedMonthsInt.Add(expense.CreationDate.Month);
            }
            orderedMonthsInt.Sort();
            List<string> orderedMonthsString = MonthsListStringToInt(orderedMonthsInt);
            return orderedMonthsString;
        }

        private int StringToIntMonth(string month)
        {
            int monthInBaseCero = (int)Enum.Parse(typeof(Months), month);
            int monthInBaseOne = monthInBaseCero + 1;
            return monthInBaseOne;
        }

        public double AmountOfExpensesInAMonth(string month)
        {
            int monthInt = StringToIntMonth(month);
            double total = 0;
            foreach (Expense expense in this.Expenses)
            {
                if (expense.CreationDate.Month == monthInt)
                    total += expense.Amount;
            }
            return total;
        }

        public List<Expense> GetExpense(string month)
        {

            int monthInt = StringToIntMonth(month);
            List<Expense> expensesByMonth = new List<Expense>();
            foreach (Expense vExpense in Expenses)
            {
                if (vExpense.CreationDate.Month == monthInt)
                    expensesByMonth.Add(vExpense);
            }
            return expensesByMonth;
        }

        public Category FindCategoryByName(string categoryName)
        {
            foreach (var category in Categories)
            {
                if (category.Name == categoryName)
                    return category;
            }
            return null;
        }


        public Expense FindExpense(string expenseDescription)
        {
            foreach (var expense in Expenses)
            {
                if (expense.Description == expenseDescription)
                    return expense;
            }
            return null;
        }

        private bool AlreadyExistTheCategoryName(string categoryName)
        {
            foreach (Category category in Categories)
            {
                if (categoryName.ToLower() == category.Name.ToLower())
                    return false;
            }
            return true;
        }

         public bool AlreadyExistThisKeyWordInAnoterCategory(string pKeyWord)
         {
            foreach (Category category in Categories)
            {
                foreach (string vKeyWord in category.KeyWords)
                {
                    if (pKeyWord.ToLower() == vKeyWord.ToLower())
                        return true;                                
                }
            }
            return false;
         }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(List<string> pKeyWords)
        {
            foreach (Category category in Categories)
            {
                foreach (string vKeyWord in category.KeyWords)
                {
                    foreach (string pKeyWord in pKeyWords)
                    {
                        if (vKeyWord.ToLower() == pKeyWord.ToLower())
                            return false;
                    }
                }
            }
            return true;
        }

        public void AddCategory(Category category)
        {
            if (!AlreadyExistTheCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            if (!AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();            
            this.Categories.Add(category);
        }                
      
        public void AddBudget(Budget vBudget)
        {
            if (vBudget is null)
            {
                throw new ArgumentNullException();
            }
            Budgets.Add(vBudget);
        }

        public void AddBudgetCategory(BudgetCategory vCategory)
        {
            if (vCategory is null)
            {
                throw new ArgumentNullException();
            }
            BudgetCategories.Add(vCategory);
        }

        public void AddExpense(Expense expense)
        {
            if (expense.Category == null)
                throw new ExcepcionExpenseWithEmptyCategory();
            Expenses.Add(expense);
        }

        public string[] GetAllMonthsString()
        {
            return Enum.GetNames(typeof(Months)).ToArray();
        }

        public string[] GetAllCategoryStrings()
        {
            List<string> categoryNames = new List<string>();

            foreach (var category in Categories)
            {
                categoryNames.Add(category.ToString());
            }
            return categoryNames.ToArray();
        }

        private Budget FindBudgetByDate(int month, int year)
        {
            foreach (var budget in Budgets)
            {
                if (budget.Month == month && budget.Year == year)
                    return budget;
            }
            return null;
        }

        public Budget BudgetGetOrCreate(string month, int year)
        {
            int monthIndex = StringToIntMonth(month);
            Budget returnBudget = FindBudgetByDate(monthIndex, year);
            if (returnBudget is null)
            {
                returnBudget = new Budget(monthIndex, Categories) { Year = year, TotalAmount = 0 };
                AddBudget(returnBudget);
            }
            return returnBudget;
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category)
        {
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description, Category = category };
            AddExpense(expense);
        }

        public void SetCategory(string vName,List<string> vKeyWords )
        {
            Category category = new Category { Name = vName, KeyWords = vKeyWords };
            AddCategory(category);
        }

        public Expense DeleteExpense(string description)
        {
            Expense expense = FindExpense(description);
            Expenses.Remove(expense);
            return expense;
        }
    }
}