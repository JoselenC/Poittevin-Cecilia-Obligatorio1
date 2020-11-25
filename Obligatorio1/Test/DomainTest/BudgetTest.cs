using System;
using System.Collections.Generic;
using System.Configuration;
using BusinessLogic;
using BusinessLogic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void TestBudgetMonth()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth) {TotalAmount=totalAmount,Year=currentYear};
            Assert.AreEqual(currentMonth, budget.Month);
        }

        [TestMethod]
        public void TestBudgetYear()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth) { TotalAmount = totalAmount, Year = currentYear };
            Assert.AreEqual(currentYear, budget.Year);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInThePass()
        {
            Months passMonth = (Months) DateTime.Now.AddMonths(-1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(passMonth) { TotalAmount = totalAmount, Year = currentYear };
            Assert.AreEqual(passMonth, budget.Month);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInTheFeature()
        {
            Months futureMonth = (Months) DateTime.Now.AddMonths(1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(futureMonth) { TotalAmount = totalAmount, Year = currentYear };
            Assert.AreEqual(futureMonth, budget.Month);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetWithYearOverOfRange()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int year = 2031;
            double totalAmount = 4000;
            new Budget(currentMonth) { TotalAmount = totalAmount, Year = year };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetWithYearUnderOfRange()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int year = 2017;
            double totalAmount = 4000;
           new Budget(currentMonth) { TotalAmount = totalAmount, Year = year };
        }

        [TestMethod]
        public void TestCreateBudgetWithYearExactlyOnUpperRangeBorder()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int year = 2030;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth) { TotalAmount = totalAmount, Year = year };
            Assert.AreEqual(budget.Year, year);
        }

        [TestMethod]
        public void TestCreateBudgetWithYearExactlyOnDownRangeBorder()
        {
            Months currentMonth = (Months) DateTime.Now.Month;
            int year = 2018;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth) { TotalAmount = totalAmount, Year = year };
            Assert.AreEqual(budget.Year, year);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            double totalAmount = 4000;
            Budget budget = new Budget((Months) DateTime.Now.Month) { TotalAmount = totalAmount, Year = DateTime.Now.Year };
            Assert.AreEqual(4000, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithCeroTotalAmount()
        {
            double totalAmount = 0;
            Budget budget = new Budget((Months) DateTime.Now.Month) { TotalAmount = totalAmount, Year = DateTime.Now.Year };
            Assert.AreEqual(0, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithBigTotalAmount()
        {
            double totalAmount = int.MaxValue;
            Budget budget = new Budget((Months) DateTime.Now.Month) { TotalAmount = totalAmount, Year = DateTime.Now.Year };
            Assert.AreEqual(int.MaxValue, budget.TotalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetWithNegativeTotalAmount()
        {
            double totalAmount = -1;
            new Budget((Months)DateTime.Now.Month) { TotalAmount = totalAmount, Year = DateTime.Now.Year };
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestUpdateBudgetWithNegativeTotalAmount()
        {
            Budget budget = new Budget((Months)DateTime.Now.Month) { TotalAmount =10, Year = DateTime.Now.Year };
            double totalAmount = -1;
            budget.TotalAmount = totalAmount;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetMothOutOfRangeGreaterThanTwelve()
        {
            new Budget((Months)13) { TotalAmount = 23, Year = DateTime.Now.Year };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBudgetMothOutOfRangeLessThanOne()
        {
            new Budget(0) { TotalAmount = 23, Year = DateTime.Now.Year };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateBudgetUpperOutOfRangeYear()
        {
            Budget budget = new Budget((Months) DateTime.Now.Month) { TotalAmount = 10, Year = DateTime.Now.Year };
            budget.Year = 2031;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateBudgetDownOutOfRangeYear()
        {
            Budget budget = new Budget((Months) DateTime.Now.Month) { TotalAmount = 10, Year = DateTime.Now.Year };
            budget.Year = 2017;

        }

        [TestMethod]
        public void BudgetToStringValidFormat()
        {
            string expectedString = "month: January year: 2020 total: 40000";
            Budget budget = new Budget(Months.January) { TotalAmount = 40000, Year = 2020 };
            Assert.AreEqual(expectedString, budget.ToString());
        }

        [TestMethod]
        public void BudgetAddBudgetCategory()
        {

            Category category1 = new Category { Name = "Category 1" };
            Budget budget = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            budget.AddBudgetCategory(category1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BudgetAddNullBudgetCategory()
        {
            Budget budget = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
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
            Budget budget = new Budget(Months.January) { TotalAmount = 0, Year = 2020 }; 
            budget.AddBudgetCategory(category1);
            budget.AddBudgetCategory(category2);

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
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            Assert.AreEqual(budget.BudgetCategories.Count, 2);
        }

        [TestMethod]
        public void GetAllBudgetCategoriesStringsValidData()
        {
            string[] expectedCategories = new string[]{
                "Category 1                      0",
                "Category 2                      0"
            };
            Category category1 = new Category { Name = "Category 1" };
            Category category2 = new Category { Name = "Category 2" };
            Budget budget = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            budget.AddBudgetCategory(category1);
            budget.AddBudgetCategory(category2);
            string[] actualCategories = budget.GetAllBudgetCategoryStrings();
            CollectionAssert.AreEqual(expectedCategories, actualCategories);
        }

        [TestMethod]
        public void EqualTrueCaseWithoutCategories()
        {
            Budget budget1 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Budget budget2 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualTrueCaseWithCategories()
        {
            List<Category> categories1 = new List<Category>()
            {
                new Category{Name="House" },
                new Category{Name="Car"},
            };
            List<Category> categories2 = new List<Category>()
            {
                new Category{Name="House"},
                new Category{Name="Car"},
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January, categories2) { Year = 2020, TotalAmount = 0 };
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualTrueCaseWithCategoriesInDiffOrder()
        {
            List<Category> categories1 = new List<Category>()
            {
                new Category{Name="House" },
                new Category{Name="Car"},
            };
            List<Category> categories2 = new List<Category>()
            {
                 new Category{Name="Car"},
                new Category{Name="House"},
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January, categories2) { Year = 2020, TotalAmount = 0 };
            Assert.AreEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffAmount()
        {
            Budget budget1 = new Budget(Months.January) { TotalAmount = 3000, Year = 2020 };
            Budget budget2 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffMonth()
        {
            Budget budget1 = new Budget(Months.March) { TotalAmount = 0, Year = 2020 };
            Budget budget2 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffYear()
        {
            Budget budget1 = new Budget(Months.January) { TotalAmount = 0, Year = 2021 };
            Budget budget2 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Assert.AreNotEqual(budget1, budget2);
        }


        [TestMethod]
        public void EqualFalseCaseDiffCategories()
        {
            List<Category> categories1 = new List<Category>()
            {
                new Category{Name="House"},
                new Category{Name="Car"},
            };
            List<Category> categories2 = new List<Category>()
            {
                 new Category{Name="House"},
                new Category{Name="School"},
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January, categories2) { Year = 2020, TotalAmount = 0 };
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffEmptyCategory()
        {
            List<Category> categories = new List<Category>()
            {
                 new Category{Name="House" },
                new Category{Name="Car" },
            };
            Budget budget1 = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January) { TotalAmount = 0, Year = 2020 };
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffBudgetCategories()
        {
            List<Category> categories1 = new List<Category>()
            {
               new Category{Name="House"},
                new Category{Name="Car"},
            };
            List<Category> categories2 = new List<Category>()
            {
              new Category{Name="House"},
                new Category{Name="Car"},
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January, categories2) { Year = 2020, TotalAmount = 0 };
            budget1.BudgetCategories[0].Amount = 10;
            Assert.AreNotEqual(budget1, budget2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffBudgetCategoriesOrder()
        {
            List<Category> categories1 = new List<Category>()
            {
                new Category{Name="House" },
                new Category{Name="Car" },
            };
            List<Category> categories2 = new List<Category>()
            {
                 new Category{Name="Car"},
                new Category{Name="House"},
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Budget budget2 = new Budget(Months.January, categories2) { Year = 2020, TotalAmount = 0 };
            budget1.BudgetCategories[0].Amount = 10;
            budget2.BudgetCategories[1].Amount = 10;
            Assert.AreEqual(budget1, budget2);
        }


        [TestMethod]
        public void EqualFalseNoBudget()
        {
            List<Category> categories1 = new List<Category>()
            {
                new Category{Name="House" },
                new Category{Name="Car" },
            };
            Budget budget1 = new Budget(Months.January, categories1) { Year = 2020, TotalAmount = 0 };
            Assert.AreNotEqual(budget1, categories1.ToArray()[0]);
        }

        [TestMethod]
        public void GetBudgetCategoryValidGetCase() {
            Category carCategory = new Category { Name = "Car"};
            Category houseCategory = new Category { Name = "House" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };

            BudgetCategory expectedBudgetCategory = new BudgetCategory { Category = carCategory, Amount = 0 };

            string categoryName = "Car";
            BudgetCategory actualBudgetCategory = budget.GetBudgetCategoryByCategoryName(categoryName);

            Assert.AreEqual(expectedBudgetCategory, actualBudgetCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindBudgetCategory))]
        public void GetBudgetCategoryNullGetCase()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };

            string categoryName = "Cartoon";
            BudgetCategory actualBudgetCategory = budget.GetBudgetCategoryByCategoryName(categoryName);

            Assert.IsNull(actualBudgetCategory);
        }

        [TestMethod]
        public void IsSameCreationDateCaseFalse()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            bool sameCreationDate = budget.IsSameCreationDate(Months.February, 2021);
            Assert.IsFalse(sameCreationDate);
        }

        [TestMethod]
        public void IsSameCreationDateCaseTrue()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
               houseCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            bool sameCreationDate = budget.IsSameCreationDate(Months.January, 2020);
            Assert.IsTrue(sameCreationDate);
        }

        [TestMethod]
        public void EditBudgetCategoryCaseTrue()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            budget.EditBudgetCategory(carCategory, houseCategory);
            Assert.AreEqual(houseCategory, budget.BudgetCategories[0].Category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditBudgetCategoryCaseNull()
        {
            Category carCategory = new Category { Name = "Car" };
            List<Category> categories = new List<Category>()
            {
               carCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            budget.EditBudgetCategory(carCategory, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindBudgetCategory))]
        public void EditBudgetCategoryCaseWrongSearch()
        {
            Category carCategory = new Category { Name = "Car" };
            Category foodCategory = new Category { Name = "Food" };
            Category houseCategory = new Category { Name = "House" };

            List<Category> categories = new List<Category>()
            {
               carCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            budget.EditBudgetCategory(foodCategory, houseCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindBudgetCategory))]
        public void EditBudgetCategoryCaseNullSearch()
        {
            Category carCategory = new Category { Name = "Car" };
            Category houseCategory = new Category { Name = "House" };

            List<Category> categories = new List<Category>()
            {
               carCategory,
            };
            Budget budget = new Budget(Months.January, categories) { Year = 2020, TotalAmount = 0 };
            budget.EditBudgetCategory(null, houseCategory);
        }
    }
}
