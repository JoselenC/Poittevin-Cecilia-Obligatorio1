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
        [ExpectedException(typeof(ExcepcionNegativeAmountExpense), "")]

        public void CreateEmptyExpense()
        {

            double amount = 0;
            string description = "";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);

        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionNegativeAmountExpense), "")]
        public void CreateExpenseNegativeAmount()
        {

            double amount = -10.5;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionInvalidAmountExpense), "")]
        public void CreateExpenseInvalidDecimalAmount()
        {

            double amount = 23.555;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionInvalidAmountExpense), "")]
        public void CreateExpenseInvalidDecimalAmount2()
        {

            double amount = 23.344;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateYear()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2031, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateYear2()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2017, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void CreatExpenseInvalidDateYear3()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidDescriptionLengthExpense), "")]
        public void CreatExpenseInvalidDescriptionLength2()
        {
            double amount = 23;
            string description = "cuando fuimos al cine de punta carretas";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidDescriptionLengthExpense), "")]
        public void CreatExpenseInvalidDescriptionLength()
        {
            double amount = 23;
            string description = "al";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense(amount, creationDate, description);
        }

        [TestMethod]
        public void CreatExpense()
        {
            double amount = 23.55;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense(amount, creationDate, description);
            Assert.AreEqual(expense.Amount, amount);
            Assert.AreEqual(expense.CreationDate, creationDate);
            Assert.AreEqual(expense.Description, description);

        }


    }
}