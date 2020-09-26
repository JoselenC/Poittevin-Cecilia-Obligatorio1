using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void TestCreateBudgetDate()
        {
            int currentMonth = DateTime.Now.Month;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, totalAmount);
            Assert.AreEqual(currentMonth, budget.currentMonth);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInThePass()
        {
            int currentDate = DateTime.Now.AddMonths(-1).Month;
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.currentMonth);
        }
        
        [TestMethod]
        public void TestCreateBudgetWithDateInTheFeature()
        {
            int currentDate = DateTime.Now.AddMonths(1).Month;
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.currentMonth);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            double totalAmount = 4000;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount);
            Assert.AreEqual(4000, budget.totalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithCeroTotalAmount()
        {
            double totalAmount = 0;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount);
            Assert.AreEqual(0, budget.totalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithBigTotalAmount()
        {
            double totalAmount = int.MaxValue;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount);
            Assert.AreEqual(int.MaxValue, budget.totalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetWithNegativeTotalAmount()
        {
            double totalAmount = -1;

            new Budget(DateTime.Now.Month, totalAmount);
        }
    }
}
