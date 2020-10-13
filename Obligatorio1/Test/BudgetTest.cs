using System;
using System.Collections.Generic;
using System.Configuration;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void TestBudgetMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, currentYear, totalAmount);
            Assert.AreEqual(currentMonth, budget.Month);
        }

        [TestMethod]
        public void TestBudgetYear()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, currentYear, totalAmount);
            Assert.AreEqual(currentYear, budget.Year);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInThePass()
        {
            int passMonth = DateTime.Now.AddMonths(-1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(passMonth, currentYear, totalAmount);
            Assert.AreEqual(passMonth, budget.Month);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInTheFeature()
        {
            int futureMonth = DateTime.Now.AddMonths(1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(futureMonth, currentYear, totalAmount);
            Assert.AreEqual(futureMonth, budget.Month);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetWithYearOverOfRange()
        {
            int currentMonth = DateTime.Now.Month;
            int Year = 2031;
            double totalAmount = 4000;
            new Budget(currentMonth, Year, totalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetWithYearUnderOfRange()
        {
            int currentMonth = DateTime.Now.Month;
            int year = 2017;
            double totalAmount = 4000;
            new Budget(currentMonth, year, totalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithYearExactlyOnUpperRangeBorder()
        {
            int currentMonth = DateTime.Now.Month;
            int year = 2030;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, year, totalAmount);
            Assert.AreEqual(budget.Year, year);
        }

        [TestMethod]
        public void TestCreateBudgetWithYearExactlyOnDownRangeBorder()
        {
            int currentMonth = DateTime.Now.Month;
            int year = 2018;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, year, totalAmount);
            Assert.AreEqual(budget.Year, year);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            double totalAmount = 4000;

            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, totalAmount);
            Assert.AreEqual(4000, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithCeroTotalAmount()
        {
            double totalAmount = 0;

            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, totalAmount);
            Assert.AreEqual(0, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithBigTotalAmount()
        {
            double totalAmount = int.MaxValue;

            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, totalAmount);
            Assert.AreEqual(int.MaxValue, budget.TotalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetWithNegativeTotalAmount()
        {
            double totalAmount = -1;

            new Budget(DateTime.Now.Month, DateTime.Now.Year, totalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestUpdateBudgetWithNegativeTotalAmount()
        {
            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, 10);
            double totalAmount = -1;
            budget.TotalAmount = totalAmount;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateBudgetUpperOutOfRangeYear()
        {
            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, 10);
            budget.Year = 2031;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateBudgetDownOutOfRangeYear()
        {
            Budget budget = new Budget(DateTime.Now.Month, DateTime.Now.Year, 10);
            budget.Year = 2017;

        }

        [TestMethod]
        public void BudgetToStringValidFormat()
        {
            string expectedString = "mes: 1 anio: 2020 total: 40000";
            Budget budget = new Budget(1, 2020, 40000);
            Assert.AreEqual(expectedString, budget.ToString());
        }

        [TestMethod]
        public void BudgetAddBudgetCategory()
        {

            Category category1 = new Category { Name = "Category 1" };
            BudgetCategory budgetCategory1 = new BudgetCategory(category1, 10);
            Budget budget = new Budget(1, 2020, 0);
            budget.AddBudgetCategory(budgetCategory1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BudgetAddNullBudgetCategory()
        {
            Budget budget = new Budget(1, 2020, 0);
            budget.AddBudgetCategory(null);
        }


        [TestMethod]
        public void GetAllCategoriesNamesValidData()
        {
            string[] expectedCategories = new string[]{
                "Category 1",
                "Category 2"
            };
            Category category1 = new Category { Name = "Category 1" };
            Category category2 = new Category { Name = "Category 2" };
            BudgetCategory budgetCategory1 = new BudgetCategory(category1, 20);
            BudgetCategory budgetCategory2 = new BudgetCategory(category2, 10);
            Budget budget = new Budget(1, 2020, 0);
            budget.AddBudgetCategory(budgetCategory1);
            budget.AddBudgetCategory(budgetCategory2);

            string[] actualCategories = budget.GetAllCategoryNames();
            CollectionAssert.AreEqual(expectedCategories, actualCategories);
        }

        [TestMethod]
        public void TestCreateBudgetWithBudgetCategories()
        {
            Category category1 = new Category { Name = "Category 1" };
            Category category2 = new Category { Name = "Category 2" };
            List<Category> categories = new List<Category>
            {
                category1,
                category2
            };
            Budget budget = new Budget(1, 2020, 0, categories);

            Assert.AreEqual(budget.BudgetCategories.Count, 2);
        }

        [TestMethod]
        public void GetAllBudgetCategoriesStringsValidData()
        {
            string[] expectedCategories = new string[]{
                "Category 1: 20",
                "Category 2: 10"
            };
            Category category1 = new Category { Name = "Category 1" };
            Category category2 = new Category { Name = "Category 2" };
            BudgetCategory budgetCategory1 = new BudgetCategory(category1, 20);
            BudgetCategory budgetCategory2 = new BudgetCategory(category2, 10);
            Budget budget = new Budget(1, 2020, 0);
            budget.AddBudgetCategory(budgetCategory1);
            budget.AddBudgetCategory(budgetCategory2);

            string[] actualCategories = budget.GetAllBudgetCategoryStrings();
            CollectionAssert.AreEqual(expectedCategories, actualCategories);
        }

        [TestMethod]
        public void EqualTrueCaseWithoutCategories()
        {
            Budget budget1 = new Budget(1, 2020, 0);
            Budget budget2 = new Budget(1, 2020, 0);
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualTrueCaseWithCategories()
        {
            List<Category> Categories1 = new List<Category>()
            {
                new Category{Name="House",KeyWords=new List<string>()  },
                new Category{Name="Car",KeyWords=new List<string>()  },
            };
            List<Category> Categories2 = new List<Category>()
            {
                new Category{Name="House",KeyWords=new List<string>()  },
                new Category{Name="Car",KeyWords=new List<string>() },
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0, Categories2);
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualTrueCaseWithCategoriesInDiffOrder()
        {
            List<Category> Categories1 = new List<Category>()
            {
                new Category{Name="House" , KeyWords=new List<string>()},
                new Category{Name="Car", KeyWords=new List<string>() },
            };
            List<Category> Categories2 = new List<Category>()
            {
                 new Category{Name="Car", KeyWords=new List<string>() },
                new Category{Name="House", KeyWords=new List<string>()},
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0, Categories2);
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffAmount()
        {
            Budget budget1 = new Budget(1, 2020, 3000);
            Budget budget2 = new Budget(1, 2020, 0);
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffMonth()
        {
            Budget budget1 = new Budget(3, 2020, 0);
            Budget budget2 = new Budget(1, 2020, 0);
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffYear()
        {
            Budget budget1 = new Budget(1, 2021, 0);
            Budget budget2 = new Budget(1, 2020, 0);
            Assert.AreNotEqual(budget1, budget2);
        }


        [TestMethod]
        public void EqualFalseCaseDiffCategories()
        {
            List<Category> Categories1 = new List<Category>()
            {
                new Category{Name="House", KeyWords=new List<string>() },
                new Category{Name="Car", KeyWords=new List<string>() },
            };
            List<Category> Categories2 = new List<Category>()
            {
                 new Category{Name="House", KeyWords=new List<string>() },
                new Category{Name="School", KeyWords=new List<string>() },
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0, Categories2);
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffEmptyCategory()
        {
            List<Category> Categories1 = new List<Category>()
            {
                 new Category{Name="House" },
                new Category{Name="Car" },
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0);
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffBudgetCategories()
        {
            List<Category> Categories1 = new List<Category>()
            {
               new Category{Name="House", KeyWords=new List<string>()},
                new Category{Name="Car", KeyWords=new List<string>()},
            };
            List<Category> Categories2 = new List<Category>()
            {
              new Category{Name="House", KeyWords=new List<string>()},
                new Category{Name="Car", KeyWords=new List<string>()},
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0, Categories2);
            budget1.BudgetCategories[0].Amount = 10;
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffBudgetCategoriesOrder()
        {
            List<Category> Categories1 = new List<Category>()
            {
                new Category{Name="House" , KeyWords=new List<string>()},
                new Category{Name="Car" , KeyWords=new List<string>()},
            };
            List<Category> Categories2 = new List<Category>()
            {
                 new Category{Name="Car", KeyWords=new List<string>()},
                new Category{Name="House", KeyWords=new List<string>()},
            };
            Budget budget1 = new Budget(1, 2020, 0, Categories1);
            Budget budget2 = new Budget(1, 2020, 0, Categories2);
            budget1.BudgetCategories[0].Amount = 10;
            budget2.BudgetCategories[1].Amount = 10;
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void GetBudgetCategoryValidGetCase() {
            Category carCategory = new Category { Name = "Car", KeyWords = new List<string>() };
            Category houseCategory = new Category { Name = "House", KeyWords = new List<string>() };
            List<Category> Categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(1, 2020, 0, Categories);

            BudgetCategory expectedBudgetCategory = new BudgetCategory(carCategory, 0);

            string categoryName = "Car";
            BudgetCategory actualBudgetCategory = budget.GetBudgetCategoryByCategoryName(categoryName);

            Assert.AreEqual(expectedBudgetCategory, actualBudgetCategory);
        }

        [TestMethod]
        public void GetBudgetCategoryNullGetCase()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };
            List<Category> Categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(1, 2020, 0, Categories);

            string categoryName = "Cartoon";
            BudgetCategory actualBudgetCategory = budget.GetBudgetCategoryByCategoryName(categoryName);

            Assert.IsNull(actualBudgetCategory);
        }
    }
}
