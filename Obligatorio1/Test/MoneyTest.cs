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
    public class MoneyTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidLengthMoneyName), "")]
        public void CreateMoneyInvalidName()
        {
            Money money = new Money { Name = "do", Quotation = 43, Symbol = "$" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidLengthSymbol), "")]
        public void CreateMoneyInvalidSymbol()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionNegativeQuotation), "")]
        public void CreateMoneyInvalidQuotation()
        {
            Money money = new Money { Name = "dolar", Quotation =0, Symbol = "" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionInvalidQuotation), "")]
        public void CreateMoneyInvalidDecimalQuotation()
        {
            Money money = new Money { Name = "dolar", Quotation = 0.345, Symbol = "" };
        }

        [TestMethod]
        public void EqualsMoneyCaseFalse()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Money money2 = new Money { Name = "pesos", Quotation = 43, Symbol = "$U" };
            Assert.AreNotEqual(money, money2);
        }

        [TestMethod]
        public void EqualsMoneyCaseTrue()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.AreEqual(money, money);
        }

        [TestMethod]
        public void EqualsMoneyCaseDifferentObject()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Category category = new Category() { Name = "entertainment" };
            Assert.AreNotEqual(money, category);
        }

        [TestMethod]
        public void SameMoneyNameCaseTrue()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.IsTrue(money.IsSameMoneyName("dolar"));
        }

        [TestMethod]
        public void SameMoneyNameCaseFalse()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.IsFalse(money.IsSameMoneyName("pesos"));
        }

        [TestMethod]
        public void ToStringMoney()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "$" };
            Assert.AreEqual("dolar",money.ToString());
        }
    }
}
