using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MoneyControllerTest
    {
        [TestMethod]
        public void DeleteMoney()
        {
            Money money = new Money() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            MemoryRepository repo = new MemoryRepository();
            MoneyController moneyController = new MoneyController(repo);
            moneyController.DeleteMoney(money);
            Assert.AreEqual(repo.GetMonies().Count, 0);
        }

        [TestMethod]
        public void FindMoney()
        {
            Money moneyExpected = new Money { Name = "dolar", Quotation = 43, Symbol = "USD" };            
            MemoryRepository repo = new MemoryRepository();
            repo.SetMoney(moneyExpected);
            MoneyController moneyController = new MoneyController(repo);
            Money money = moneyController.FindMoney(moneyExpected);
            Assert.AreEqual(money, moneyExpected);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindMoney), "")]
        public void NoFindMoney()
        {
            Money moneyExpected = new Money { Name = "euros", Quotation = 43, Symbol = "E" };
            Money money2 = new Money { Name = "dolar", Quotation = 43, Symbol = "USD" };
            MemoryRepository repo = new MemoryRepository();            
            repo.SetMoney(moneyExpected);
            MoneyController moneyController = new MoneyController(repo);
            moneyController.FindMoney(money2);
        }

        [TestMethod]
        public void GetMonies()
        {
            Money money = new Money() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Money> moniesExpected = new List<Money>() {
                money,
            };
            MemoryRepository repo = new MemoryRepository();
            MoneyController moneyController = new MoneyController(repo);
            List<Money> monies = moneyController.GetMonies();
            CollectionAssert.AreEqual(moniesExpected, monies);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheMoneyName), "")]
        public void SetMonySameName()
        {
            MemoryRepository repo = new MemoryRepository();
            MoneyController moneyController = new MoneyController(repo);
            moneyController.setMoney("pesos","$U",43);
            moneyController.setMoney("pesos", "$", 43);

        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheMoneySymbol), "")]
        public void SetMoneySameSymbol()
        {
            MemoryRepository repo = new MemoryRepository();
            MoneyController moneyController = new MoneyController(repo);
            moneyController.setMoney("dolares", "$U", 43);
        }

        [TestMethod]
        public void SetMoneyValidCase()
        {
            Money money = new Money { Name = "dolar", Quotation = 43, Symbol = "USD" };
            Money money2 = new Money { Name = "euro", Quotation = 43, Symbol = "E" };
            Money money3 = new Money() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Money> moniesExpected = new List<Money>() {
                money3,
                money,
                money2,
            };
            MemoryRepository repo = new MemoryRepository();
            MoneyController moneyController = new MoneyController(repo);
            moneyController.setMoney("dolar", "USD", 43);
            moneyController.setMoney("euro", "E", 43);
            CollectionAssert.AreEqual(moneyController.GetMonies(), moniesExpected);
        }
    }
}
