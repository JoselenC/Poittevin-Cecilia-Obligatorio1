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
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };

        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionNegativeAmountExpense), "")]
        public void CreateExpenseNegativeAmount()
        {

            double amount = -10.5;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionInvalidAmountExpense), "")]
        public void CreateExpenseInvalidDecimalAmount()
        {

            double amount = 23.555;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateFutureYear()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2031, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateLastYear()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2017, 2, 2);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void CreatExpenseInvalidDateYearZero()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidDescriptionLengthExpense), "")]
        public void CreatExpenseInvalidDescriptionLength()
        {
            double amount = 23;
            string description = "cuando fuimos al cine de punta carretas";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidDescriptionLengthExpense), "")]
        public void CreatExpenseShortDescription()
        {
            double amount = 23;
            string description = "al";
            DateTime creationDate = new DateTime(2021, 2, 2);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        public void CreatExpenseValidData()
        {
            double amount = 23.55;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate =new DateTime(2020, 01, 01), Description = description };
            Assert.AreEqual(amount,expense.Amount);
            Assert.AreEqual(creationDate,expense.CreationDate);
            Assert.AreEqual(description,expense.Description);

        }


    }
}