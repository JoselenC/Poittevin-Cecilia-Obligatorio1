using BusinessLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate,description);

        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseNegativeAmount()
        {

            double amount = -10.5;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseInvalidAmount()
        {

            double amount = 23.555;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseInvalidAmount2()
        {

            double amount = 23.344;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2031, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear2()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2017, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear3()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense(amount, creationDate,description);
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
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void creatExpenseInvalidDescription()
        {
            double amount = 23;
            string description = "aa";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        public void creatExpense()
        {
            double amount = 23.55;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate,description);
            Assert.AreEqual(expense.amount, amount);
            Assert.AreEqual(expense.creationDate, creationDate);
            Assert.AreEqual(expense.description, description);

        }

       
        }


}
