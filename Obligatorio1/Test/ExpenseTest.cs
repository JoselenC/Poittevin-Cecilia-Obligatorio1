using BusinessLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ExpenseTest
    {
        [TestMethod]
        public void createEmptyExpense()
        {
            Expense emptyExpense = new Expense();
            int amount = 0;
            DateTime creationDate = DateTime.MinValue;
            Assert.AreEqual(emptyExpense.amount, amount);
            Assert.AreEqual(emptyExpense.creationDate, creationDate);
        }
    }
}
