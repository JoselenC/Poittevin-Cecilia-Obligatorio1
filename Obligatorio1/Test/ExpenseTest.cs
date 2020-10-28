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
            string description ="when I went to the movies";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]

        [ExpectedException(typeof(ExcepcionInvalidAmountExpense), "")]
        public void CreateExpenseInvalidDecimalAmount()
        {

            double amount = 23.555;
            string description ="when I went to the movies";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateFutureYear()
        {
            double amount = 23;
            string description = "when I went to the movies";
            DateTime creationDate = new DateTime(2031, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidYearExpense), "")]
        public void CreatExpenseInvalidDateLastYear()
        {
            double amount = 23;
            string description = "when I went to the movies";
            DateTime creationDate = new DateTime(2017, 2, 2);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void CreatExpenseInvalidDateYearZero()
        {
            double amount = 23;
            string description = "when I went to the movies";
            DateTime creationDate = new DateTime(0, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidDescriptionLengthExpense), "")]
        public void CreatExpenseInvalidDescriptionLength()
        {
            double amount = 23;
            string description ="when we went to the Punta Carretas cinema";
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
            string description = "when go to the movie";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate =creationDate, Description = description };
            Assert.AreEqual(amount,expense.Amount);
            Assert.AreEqual(creationDate,expense.CreationDate);
            Assert.AreEqual(description,expense.Description);

        }

        [TestMethod]
        public void EqualFalseCaseDiffAmount()
        {
            string description = "when go to the movie";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = 23, CreationDate = creationDate, Description = description };
            Expense expense2 = new Expense { Amount = 23.5, CreationDate = creationDate, Description = description };
            Assert.AreNotEqual(expense, expense2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffDescription()
        {
            double amount=23.5;
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = "when go to the movie"};
            Expense expense2 = new Expense { Amount = amount, CreationDate = creationDate, Description = "when I went to eat"};
            Assert.AreNotEqual(expense, expense2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffCreationDate()
        {
            double amount = 23.5;
            string description = "when go to the movie";
            Expense expense = new Expense { Amount = amount, CreationDate = new DateTime(2020, 01, 01), Description = description };
            Expense expense2 = new Expense { Amount = amount, CreationDate = new DateTime(2021, 01, 01), Description = description};
            Assert.AreNotEqual(expense, expense2);
        }

        [TestMethod]
        public void EqualTrueEqualsExpenses()
        {
            double amount = 23.5;
            string description = "when go to the movie";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
            Expense expense2 = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
            Assert.AreEqual(expense, expense2);
        }

        [TestMethod]
        public void EqualFalseNoExpense()
        {
            double amount = 23.5;
            string description = "when go to the movie";
            DateTime creationDate = new DateTime(2020, 01, 01);
            Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
            Category category = new Category() { KeyWords = new KeyWord(), Name = "Entertainment" };
            Assert.AreNotEqual(expense, category);
        }

        [TestMethod]
        public void ToStringOnlyNameFormatValid()
        {
            Expense expense = new Expense { Description = "Dinner", Amount = 23, CreationDate = new DateTime(2020, 01, 01) };
            string expectedFormat = "Dinner";
            string actualFormat = expense.ToString();
            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void ISameCreationDateCaseTrue()
        {
            Expense expense = new Expense { Description = "Dinner", Amount = 23, CreationDate = new DateTime(2020, 01, 01) };
            bool sameCreationDate = expense.IsExpenseSameMonth(Months.January);
            Assert.IsTrue(sameCreationDate);
        }

        [TestMethod]
        public void ISameCreationDateCaseFalse()
        {
            Expense expense = new Expense { Description = "Dinner", Amount = 23, CreationDate = new DateTime(2020, 01, 01) };
            bool sameCreationDate = expense.IsExpenseSameMonth(Months.February);
            Assert.IsFalse(sameCreationDate);
        }


    }
}