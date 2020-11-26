using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;

namespace Test
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidLengthCurrencyName), "")]
        public void CreatecurrencyInvalidName()
        {
            Currency currency = new Currency { Name = "do", Quotation = 43, Symbol = "$" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidLengthSymbol), "")]
        public void CreatecurrencyInvalidSymbol()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionNegativeQuotation), "")]
        public void CreatecurrencyInvalidQuotation()
        {
            Currency currency = new Currency { Name = "dolar", Quotation =0, Symbol = "" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidQuotation), "")]
        public void CreatecurrencyInvalidDecimalQuotation()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 0.345, Symbol = "" };
        }

        [TestMethod]
        public void EqualscurrencyCaseFalse()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Currency currency2 = new Currency { Name = "pesos", Quotation = 43, Symbol = "$U" };
            Assert.AreNotEqual(currency, currency2);
        }

        [TestMethod]
        public void EqualscurrencyCaseTrue()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.AreEqual(currency, currency);
        }

        [TestMethod]
        public void EqualscurrencyCaseDifferentObject()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Category category = new Category() { Name = "entertainment" };
            Assert.AreNotEqual(currency, category);
        }

        [TestMethod]
        public void SamecurrencyNameCaseTrue()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.IsTrue(currency.IsSameCurrencyName("dolar"));
        }

        [TestMethod]
        public void SamecurrencyNameCaseFalse()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.IsFalse(currency.IsSameCurrencyName("pesos"));
        }

        [TestMethod]
        public void ToStringcurrency()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.AreEqual("dolar",currency.ToString());
        }
    }
}
