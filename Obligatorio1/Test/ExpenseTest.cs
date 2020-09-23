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

        [TestMethod]
        public void creatNotEmptyExpense()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.AreEqual(expense.amount, amount);
            Assert.AreEqual(expense.creationDate, creationDate);

        }

        [TestMethod]
        public void creatExpenseInvalidDate()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }
    }


}
