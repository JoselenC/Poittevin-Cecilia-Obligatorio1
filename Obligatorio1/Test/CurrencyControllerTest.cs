using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.Repository;
using DataAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CurrencyControllerTest
    {
        [TestMethod]
        public void Deletecurrency()
        {
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            IManageRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.DeleteCurrency(currency);
            Assert.AreEqual(repo.GetCurrencies().Count, 0);
        }

        [TestMethod]
        public void Findcurrency()
        {
            Currency currencyExpected = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            IManageRepository repo = new ManageMemoryRepository();
            repo.SetCurrency(currencyExpected);
            CurrencyController currencyController = new CurrencyController(repo);
            Currency currency = currencyController.FindCurrency(currencyExpected);
            Assert.AreEqual(currency, currencyExpected);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCurrency), "")]
        public void NoFindcurrency()
        {
            Currency currencyExpected = new Currency { Name = "euros", Quotation = 43, Symbol = "E" };
            Currency currency2 = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            IManageRepository repo = new ManageMemoryRepository();            
            repo.SetCurrency(currencyExpected);
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.FindCurrency(currency2);
        }

        [TestMethod]
        public void GetMonies()
        {
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Currency> moniesExpected = new List<Currency>() {
                currency,
            };
            IManageRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            List<Currency> monies = currencyController.GetCurrencies();
            CollectionAssert.AreEqual(moniesExpected, monies);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheCurrencyName), "")]
        public void SetMonySameName()
        {
            IManageRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency("pesos","$U",43);
            currencyController.SetCurrency("pesos", "$", 43);

        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheCurrencySymbol), "")]
        public void SetcurrencySameSymbol()
        {
            IManageRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency("dolares", "$U", 43);
        }

        [TestMethod]
        public void SetcurrencyValidCase()
        {
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            Currency currency2 = new Currency { Name = "euro", Quotation = 43, Symbol = "E" };
            Currency currency3 = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Currency> moniesExpected = new List<Currency>() {
                currency3,
                currency,
                currency2,
            };
            IManageRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency("dolar", "USD", 43);
            currencyController.SetCurrency("euro", "E", 43);
            CollectionAssert.AreEqual(currencyController.GetCurrencies(), moniesExpected);
        }

        [TestMethod]
        public void Editcurrency()
        {

            DateTime month = new DateTime(2020, 8, 24);
            Currency currency = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            Currency currency2 = new Currency { Name = "euro", Quotation = 40, Symbol = "E" };
            Category category = new Category() { Name="Entertainment" };
            Expense expense1 = new Expense { Amount = 23, CreationDate = month, Description = "entertainment", Currency=currency2,Category=category};
            IManageRepository repository = new ManageMemoryRepository();
            repository.SetExpense(23,month,"entertainment",category,currency);
            CurrencyController currencyController = new CurrencyController(repository);
            currencyController.EditCurrency(currency, "euro", "E",40);
            Assert.AreEqual(currencyController.Repository.GetExpenses().ToArray()[0].Currency,expense1.Currency);
        }
    }

}
