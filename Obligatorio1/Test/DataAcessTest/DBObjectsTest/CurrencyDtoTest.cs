using System;
using DataAcess.DBObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataAcessTest.DBObjectsTest
{
    [TestClass]
    public class CurrencyDtoTest
    {
        [TestMethod]
        public void SetGetCurrencyDtoID()
        {
            CurrencyDto currencyDto = new CurrencyDto();
            currencyDto.CurrencyDtoID = 23;
            Assert.AreEqual(23, currencyDto.CurrencyDtoID);
        }

        [TestMethod]
        public void SetGeName()
        {
            CurrencyDto currencyDto = new CurrencyDto();
            currencyDto.Name = "dolares";
            Assert.AreEqual("dolares", currencyDto.Name);
        }

        [TestMethod]
        public void SetGetSymbol()
        {
            CurrencyDto currencyDto = new CurrencyDto();
            currencyDto.Symbol = "USD";
            Assert.AreEqual("USD", currencyDto.Symbol);
        }

        [TestMethod]
        public void SetGetQuotation()
        {
            CurrencyDto currencyDto = new CurrencyDto();
            currencyDto.Quotation = 43;
            Assert.AreEqual(43, currencyDto.Quotation);
        }
    }
}
