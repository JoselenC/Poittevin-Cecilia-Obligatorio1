using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    enum Months
    {
        Enero,
        Febrero,
        Marzo,
        Abril,
        Mayo,
        Junio,
        Julio,
        Agosto,
        Setiembre,
        Octubre,
        Noviembre,
        Diciembre
    }
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
             

        public Repository(List<Category> categoriesReceived)
        {
            Expenses = new List<Expense>();
            Budgets = new List<Budget>();
            BudgetCategories = new List<BudgetCategory>();
            Categories = categoriesReceived;
        }



        public Category FindCategoryByDescription(string description)
        {
            Category category = null;
            string[] desc = description.Split(' ');
            bool exist = false;
            int cont = 0;
            for (int i = 0; i < Categories.Count; i++)
            {
                exist = false;
                for (int j = 0; j < desc.Length && !exist; j++)
                {
                    exist = Categories[i].KeyWords.Contains(desc[j]);
                }
                if (exist)
                {
                    category = Categories[i];
                    cont = cont + 1;
                }
            }
            if (cont == 1)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        private List<string> MonthsListStringToInt(List<int> months)
        {
            List<string> monthsString = new List<string>();
            for (int i = 0; i < months.Count; i++)
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(months[i]);
                monthsString.Add(nombreMes);
            }
            return monthsString;
        }

        public List<string> OrderedMonthsInWhichThereAreExpenses()
        {
            List<int> orderedMonthsInt = new List<int>();
            for (int i = 0; i < Expenses.Count; i++)
            {
                Expense expense = Expenses[i];
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

        public double ExpensesByMonth(string month)
        {
            int monthInt = StringToIntMonth(month);
            double total = 0;
            for (int i = 0; i < this.Expenses.Count; i++)
            {
                Expense expense = this.Expenses[i];
                if (expense.CreationDate.Month == monthInt)
                    total += expense.Amount;
            }
            return total;
        }   

        
        public List<string[]> ExpenseReport(string month)
        {
            
            int monthInt = StringToIntMonth(month);
            List<string[]> reports = new List<string[]>();
            for (int i = 0; i < this.Expenses.Count; i++)
            {
                string[] report = new string[4];
                Expense expense = this.Expenses[i];
                if (expense.CreationDate.Month == monthInt )
                {
                    string date = expense.CreationDate.ToString("dd/MM/yyyy");
                    string description = expense.Description;
                    string name = expense.Category.Name;
                    string amount = expense.Amount.ToString();

                    report[0] = date;
                    report[1] = description;
                    report[2] = name;
                    report[3] = amount;

                }
                reports.Add(report);
            }
            return reports;
        }


        private bool AlreadyExistTheCategoryName(string categoryName)
        {
            bool validName = true;
            for (int i = 0; i < Categories.Count; i++)
            {
                if (categoryName.ToLower() == Categories[i].Name.ToLower())
                {
                    validName= false;
                }

            }
            return validName;
        }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(List<string> keyWords)
        {
            bool areValidKeyWords = true;
            for (int i = 0; i < Categories.Count; i++)
            {
                for (int k = 0; k < Categories[i].KeyWords.Count; k++)
                {
                    for (int j = 0; j < keyWords.Count; j++)
                    {
                        string keyWord = Categories[i].KeyWords[k];
                        string vkeyWord = keyWords[j];
                        if (keyWord.ToLower() == vkeyWord.ToLower())
                        {
                            areValidKeyWords = false;
                        }
                    }
                }

            }
            return areValidKeyWords;
        }

        public void AddCategoryToCategories(Category category)
        {
            if (!AlreadyExistTheCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            if (!AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();            
            this.Categories.Add(category);                
            
           
        }    

        public void AddExpenseToExpenses(Expense expense)
        {
           if (expense.Category == null)
                throw new ExcepcionExpenseWithEmptyCategory();
            Expenses.Add(expense);

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
                returnBudget = new Budget(monthIndex, year, 0, Categories);
                AddBudget(returnBudget);
            }
            return returnBudget;
        }

    }
}