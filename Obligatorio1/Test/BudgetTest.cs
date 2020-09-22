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
            int totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount);
            Assert.AreEqual(currentDate, budget.date);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            int totalAmount = 4000;

            Budget budget = new Budget(DateTime.Now, totalAmount);
            Assert.AreEqual(4000, budget.totalAmount);
        }
    }
}
