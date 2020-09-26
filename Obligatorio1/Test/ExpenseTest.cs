using BusinessLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ExpenseTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]

        public void createEmptyExpense()
        {

            double amount = 0;
            string description = "";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate,description);

        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseNegativeAmount()
        {

            double amount = -10.5;
            string description = "";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear()
        {
            double amount = 23;
            string description = "";
            DateTime creationDate = new DateTime(2031, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear2()
        {
            double amount = 23;
            string description = "";
            DateTime creationDate = new DateTime(2017, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void creatExpenseInvalidDescription2()
        {
            double amount = 23;
            string description = "cuando fuimos al cine de punta carretas";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        public void creatExpense()
        {
            int amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate,description);
            Assert.AreEqual(expense.amount, amount);
            Assert.AreEqual(expense.creationDate, creationDate);
            Assert.AreEqual(expense.description, description);

        }
    }


}
