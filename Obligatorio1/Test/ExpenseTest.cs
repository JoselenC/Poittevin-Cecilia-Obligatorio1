using BusinessLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ExpenseTest
    {
        [TestMethod]
        public void createExpenseZeroAmount()
        {
            
            int amount = 0;
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense emptyExpense = new Expense(amount,creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void createExpenseNegativeAmount()
        {

            int amount = -10;
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense emptyExpense = new Expense(amount, creationDate);
            Assert.Fail();
        }


        [TestMethod]
        public void creatExpenseInvalidDateYear()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateYear2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(-1, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateYear3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateMonth()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 31, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateMonth2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 0, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateMonth3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, -1, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateDay()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020,10,40);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateDay2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 10, 0);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDateDay3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 10, -1);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        public void creatExpenseInvalidDate()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 35, 40);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }


        [TestMethod]
        public void creatExpense()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate);
            Assert.AreEqual(expense.amount, amount);
            Assert.AreEqual(expense.creationDate, creationDate);

        }
    }


}
