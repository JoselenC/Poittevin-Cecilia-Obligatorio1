using BusinessLogic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Budget
    {

        private double totalAmount;

        private readonly Months month;

        private int year;

        public double TotalAmount { get => totalAmount; set => SetTotalAmount(value); }

        public Months Month { get => month ; }

        public int Year { get => year; set => SetYear(value); }

        public List<BudgetCategory> BudgetCategories { get; set; }

        private void SetTotalAmount(double vTotalAmount)
        {
            if (vTotalAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            totalAmount = vTotalAmount;
        }

        private void SetYear(int vYear)
        {
            if (vYear > 2030 || vYear < 2018 )
                throw new ArgumentOutOfRangeException();
            year = vYear;
        }

        private bool ValidMonth(Months vMonth)
        {
            if ((int) vMonth > 12 || (int) vMonth < 1)
                throw new ArgumentOutOfRangeException();
            return true;
        }

        public Budget(Months vCurrentMonth)
        {
            if (ValidMonth(vCurrentMonth))
            {
                month = vCurrentMonth;
                BudgetCategories = new List<BudgetCategory>();
            }
        }

        private List<BudgetCategory> GenerateBudgetCategoryList(List<Category> categories)
        {
            List<BudgetCategory> returnList = new List<BudgetCategory>();
            foreach (var category in categories)
                returnList.Add(new BudgetCategory { Category = category, Amount = 0 });
            return returnList;
        }

        public Budget(Months vCurrentMonth, List<Category> categories)
        {
            if (ValidMonth(vCurrentMonth))
            {
                month = vCurrentMonth;
                BudgetCategories = GenerateBudgetCategoryList(categories);
            }
        }

        public override string ToString()
        {
            return $"month: {month} year: {Year} total: {totalAmount}";
        }

        public void AddBudgetCategory(Category category)
        {
            try
            {
                FindBudgetCategory(category);
            }
            catch (NoFindBudgetCategory)
            {
                BudgetCategory budgetCategory = new BudgetCategory() { Amount = 0, Category = category };
                BudgetCategories.Add(budgetCategory);
            }
        }

        public string[] GetAllCategoryNames()
        {
            List<string> returnNames = new List<string>();
            foreach (var budgetCategory in BudgetCategories)
            {
                returnNames.Add(budgetCategory.Category.ToString());
            }
            return returnNames.ToArray();
        }

        public string[] GetAllBudgetCategoryStrings()
        {
            List<string> returnNames = new List<string>();
            foreach (var budgetCategory in BudgetCategories)
            {
                returnNames.Add(budgetCategory.ToString());
            }
            return returnNames.ToArray();
        }

        public BudgetCategory GetBudgetCategoryByCategoryName(string categoryName)
        {
            foreach (var budgetCategory in BudgetCategories)
            {
                if (budgetCategory.Category.Name == categoryName)
                    return budgetCategory;
            }
            throw new NoFindBudgetCategory();
        }
        
        private BudgetCategory FindBudgetCategory(Category category)
        {
            BudgetCategory budgetCategory = BudgetCategories.Find(e => e.Category == category);
            if(budgetCategory is null)
                throw new NoFindBudgetCategory();
            return budgetCategory;
        }

        public void EditBudgetCategory(Category oldCategory, Category newCategory)
        {
            BudgetCategory budgetCategory = FindBudgetCategory(oldCategory);
            budgetCategory.Category = newCategory;
        }

        public override bool Equals(object obj)
        {
            if (obj is Budget budget)
            {
                bool boolTotalAmount = totalAmount == budget.totalAmount;
                bool boolMonth = month == budget.month;
                bool boolYear = year == budget.year;
                bool equalBudgetCategory = BudgetCategories.OrderBy(t => t.Category.Name).SequenceEqual(budget.BudgetCategories.OrderBy(t => t.Category.Name));
                return boolTotalAmount &&
                       boolMonth &&
                       boolYear &&
                       equalBudgetCategory;
            }
            return false;
        }

       public bool IsSameCreationDate(Months month, int year)
        {
            return Month == month && Year == year;
        }

      

    }
}