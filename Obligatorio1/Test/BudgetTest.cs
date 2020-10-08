using System;
using System.Configuration;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void TestCreateBudgetMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, currentYear, totalAmount);
            Assert.AreEqual(currentMonth, budget.Month);
        }

        [TestMethod]
        public void TestCreateBudgetYear()
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

    }
}
