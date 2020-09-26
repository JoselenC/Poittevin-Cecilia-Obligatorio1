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
            DateTime currentDate = DateTime.Now;
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.date);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInThePass()
        {
            DateTime currentDate = DateTime.Now.AddDays(-2);
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.date);
        }
        
        [TestMethod]
        public void TestCreateBudgetWithDateInTheFeature()
        {
            DateTime currentDate = DateTime.Now.AddDays(2);
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.date);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            double totalAmount = 4000;

            Budget budget = new Budget(DateTime.Now, totalAmount);
            Assert.AreEqual(4000, budget.totalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithCeroTotalAmount()
        {
            double totalAmount = 0;

            Budget budget = new Budget(DateTime.Now, totalAmount);
            Assert.AreEqual(0, budget.totalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithBigTotalAmount()
        {
            double totalAmount = int.MaxValue;

            Budget budget = new Budget(DateTime.Now, totalAmount);
            Assert.AreEqual(int.MaxValue, budget.totalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetWithNegativeTotalAmount()
        {
            double totalAmount = -1;

            new Budget(DateTime.Now, totalAmount);
        }
    }
}
