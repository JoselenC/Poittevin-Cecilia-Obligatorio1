using BusinessLogic;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ExpenseReportLineTest
    {
        [TestMethod]
        public void EqualsCaseTrue()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() {Name = "entertainment",};
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020,01,01),
                Description = "dinner",
                Currency = currency
            };

            Assert.AreEqual(expenseReportLine, expenseReportLine);
        }

        [TestMethod]
        public void EqualsCaseTrueCurrencynull()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = null,
            };

            Assert.AreEqual(expenseReportLine, expenseReportLine);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffAmount()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            ExpenseReportLine expenseReportLine2 = new ExpenseReportLine()
            {
                Amount = 23.5,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            Assert.AreNotEqual(expenseReportLine, expenseReportLine2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffCategory()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            Category categoryFood = new Category() { Name = "food", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            ExpenseReportLine expenseReportLine2 = new ExpenseReportLine()
            {
                Amount = 23.5,
                Category = categoryFood,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            Assert.AreNotEqual(expenseReportLine, expenseReportLine2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffCurrency()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Currency currency2 = new Currency { Name = "Peso", Symbol = "$U", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            ExpenseReportLine expenseReportLine2 = new ExpenseReportLine()
            {
                Amount = 23.5,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency2
            };
            Assert.AreNotEqual(expenseReportLine, expenseReportLine2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffDescription()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            ExpenseReportLine expenseReportLine2 = new ExpenseReportLine()
            {
                Amount = 23.5,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "movie",
                Currency = currency
            };
            Assert.AreNotEqual(expenseReportLine, expenseReportLine2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffObj()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "dinner",
                Currency = currency
            };
            Assert.AreNotEqual(expenseReportLine,currency);
        }

        [TestMethod]
        public void GetCategory()
        {
            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryEntertainment = new Category() { Name = "entertainment", };
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = 23.5,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 01, 01),
                Description = "movie",
                Currency = currency
            };
            Assert.AreEqual(categoryEntertainment, expenseReportLine.Category);
        }
    }
}
