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
            Budget budget = Budget(currentDate, 4000);
            Assert.AreEqual(currentDate, budget.date);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            Budget budget = Budget(DateTime.Now, 4000);
            Assert.AreEqual(4000, budget.totalAmount);
        }
    }
}
