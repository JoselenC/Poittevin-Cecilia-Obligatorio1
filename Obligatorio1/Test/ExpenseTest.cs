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
            int amount = 23;
            DateTime creationDate = new DateTime(-1, 2, 2);
            Expense expense = new Expense(amount, creationDate);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateMonth()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 31, 01);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateMonth2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 0, 01);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateMonth3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, -1, 01);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateDay()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 10, 40);
            Expense expense = new Expense(amount, creationDate);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateDay2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 10, 0);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateDay3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2020, 10, -1);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
     [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDate()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 35, 40);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        //February cannot have thirty days
        public void creatExpenseInvalidDate2()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 2, 30);
            Expense expense = new Expense(amount, creationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        //April cannot have fthirty one days
        public void creatExpenseInvalidDate3()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 4, 31);
            Expense expense = new Expense(amount, creationDate);
        }

         [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDate4()
        {
            int amount = 23;
            DateTime creationDate = new DateTime(2030, 1, 32);
            Expense expense = new Expense(amount, creationDate);
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
