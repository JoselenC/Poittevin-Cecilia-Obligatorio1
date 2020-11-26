using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using BusinessLogic;
using DataAcess.DBObjects;

namespace DataAcess.Mappers.Tests
{
    [TestClass()]
    public class CurrencyMapperTest
    {
        public static DataBaseRepository<Currency, CurrencyDto> Currencies;
        public static Currency currencyDolar;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            Currencies = new DataBaseRepository<Currency, CurrencyDto>(new CurrencyMapper());
            CleanData();
            currencyDolar = new Currency()
            {
                Name = "Dolar",
                Symbol = "U$S",
                Quotation = 43
            };
            Currencies.Add(currencyDolar);
        }

        private static void CleanData()
        {
            foreach (Currency currency in Currencies.Get())
            {
                Currencies.Delete(currency);
            }
        }
        
        [TestMethod()]
        public void DomainToDtoTest()
        {
            Currency currencyTest = new Currency()
            {
                Name = "Test",
                Symbol = "T",
                Quotation = 2
            };
            Currencies.Add(currencyTest);
            Currency realCurrency = Currencies.Find(x => x.Name == "Test");
            Assert.AreEqual(currencyTest, realCurrency);
            Currencies.Delete(currencyTest);
        }

        [TestMethod()]
        public void DtoToDomainTest()
        {
            Currency realCurrency = Currencies.Find(x => x.Name == "Dolar");
            Assert.AreEqual(currencyDolar, realCurrency);
        }

        [TestMethod()]
        public void UpdateDtoObjectTest()
        {
            Currency newDolar = new Currency()
            {
                Name = "Dolar",
                Symbol = "U$S",
                Quotation = 23
            };
            Currencies.Update(currencyDolar, newDolar);
            Currency realCurrency = Currencies.Find(x => x.Name == "Dolar");
            Assert.AreEqual(newDolar, realCurrency);
            Currencies.Update(newDolar, currencyDolar);
        }
    }
}