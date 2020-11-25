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
        private static ManagerRepository repo;
        private static CurrencyController currencyController;
        private static Currency currencyPeso;

        [ClassInitialize()]

        public static void TestFixtureSetup(TestContext context)
        { 
            repo = new ManageMemoryRepository();
            currencyController = new CurrencyController(repo);
            currencyPeso = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };

            currencyController.SetCurrency(currencyPeso);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NoFindCurrency), "")]

        public void Deletecurrency()
        {
            Currency currency = new Currency() { Name = "PesoTest", Symbol = "A", Quotation = 1 };
            currencyController.SetCurrency(currency);

            currencyController.DeleteCurrency(currency);
            currencyController.FindCurrency(currency);
        }

        [TestMethod]
        public void Findcurrency()
        {           
            Currency currency = currencyController.FindCurrency(currencyPeso);
            Assert.AreEqual(currency, currencyPeso);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCurrency), "")]
        public void NoFindcurrency()
        {
            Currency currency2 = new Currency { Name = "dolarTest", Quotation = 43, Symbol = "USD" };
            currencyController.FindCurrency(currency2);
        }

        [TestMethod]
        public void GetCurrenciesSuccessCase()
        {

            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Currency> currenciesExpected = new List<Currency>() {
                currency,
            };
            List<Currency> currencies = currencyController.GetCurrencies();
            CollectionAssert.AreEqual(currenciesExpected, currencies);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheCurrencyName), "")]
        public void SetCurrencySameName()
        {
            currencyController.SetCurrency(new Currency() { 
                Name = "Pesos", 
                Symbol = "A", 
                Quotation = 1 
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionAlreadyExistTheCurrencySymbol), "")]
        public void SetCurrencySameSymbol()
        {
            currencyController.SetCurrency(new Currency() { Name = "Dolar", 
                Symbol = "$U",
                Quotation = 43 
            });
        }

        [TestMethod]
        public void SetcurrencyValidCase()
        {

            Currency currencyDolar = new Currency { Name = "Dolar", Quotation = 43, Symbol = "USD" };
            Currency currencyEuro = new Currency { Name = "Euro", Quotation = 43, Symbol = "E" };
            List<Currency> moniesExpected = new List<Currency>() {
                currencyPeso,
                currencyDolar,
                currencyEuro,
            };

            currencyController.SetCurrency(currencyDolar);
            currencyController.SetCurrency(currencyEuro);

            CollectionAssert.AreEqual(currencyController.GetCurrencies(), moniesExpected);
            currencyController.DeleteCurrency(currencyDolar);
            currencyController.DeleteCurrency(currencyEuro);

        }
    }

}
