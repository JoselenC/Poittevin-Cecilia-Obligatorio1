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

        public void DeletecurrencyNoFind()
        {
            Currency currency = new Currency() { Name = "PesoTest", Symbol = "A", Quotation = 1 };
            currencyController.SetCurrency(currency);

            currencyController.DeleteCurrency(currency);
            currencyController.FindCurrency(currency);
        }

        [TestMethod]
        public void Deletecurrency()
        {
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            ManagerRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            ExpenseController expenseController = new ExpenseController(repo);
            Currency currency2 = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Category categoryFood = new Category() { Name = "food" };
            Expense expense = new Expense() { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "Testing Dinner", Category = categoryFood, Currency = currency2 };
            expenseController.SetExpense(expense);
            currencyController.SetCurrency(currency);
            currencyController.SetCurrency(currency2);
            currencyController.DeleteCurrency(currency);
            Assert.AreEqual(currencyController.GetCurrencies().Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoDeleteCurrency), "")]
        public void DeletCurrencyInExpense()
        {
            ManagerRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            ExpenseController expenseController = new ExpenseController(repo);
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Category categoryFood = new Category() { Name = "food" };
            Expense expense= new Expense() { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "Testing Dinner", Category =categoryFood, Currency=currency };
            expenseController.SetExpense(expense);
            currencyController.SetCurrency(currency);
            currencyController.DeleteCurrency(currency);

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

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateCurrency()
        {
            Currency oldCurrency = new Currency { Name = "dolares", Quotation = 43, Symbol = "a" };
            Currency newCurrency = new Currency { Name = "euros", Quotation = 43, Symbol = "b" };
            List<Currency> currencies = new List<Currency>() { newCurrency };
            ManagerRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency(oldCurrency);          
            currencyController.UpdateCurrency(oldCurrency, newCurrency);
            Assert.AreEqual(currencyController.GetCurrencies(), currencies);
        }

        [TestMethod]
        public void FindCurrencyByNAme()
        {
            Currency currencyExpected = new Currency { Name = "dolares", Quotation = 43, Symbol = "a" };          
            ManagerRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency(currencyExpected);
            Currency currency =currencyController.FindCurrencyByName("dolares");
            Assert.AreEqual(currencyExpected, currency);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void NoFindCurrencyByNAme()
        {
            Currency currencyExpected = new Currency { Name = "dolares", Quotation = 43, Symbol = "a" };
            ManagerRepository repo = new ManageMemoryRepository();
            CurrencyController currencyController = new CurrencyController(repo);
            currencyController.SetCurrency(currencyExpected);
            Currency currency = currencyController.FindCurrencyByName("euros");
        }
    }

}
