using System;
using DataAcess.DBObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataAcessTest.DBObjectsTest
{
    [TestClass]
    public class ExpenseDtoTest
    {
        [TestMethod]
        public void GetSetExpenseDtoID()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.ExpenseDtoID = 12;
            Assert.AreEqual(12, expenseDto.ExpenseDtoID);
        }

        [TestMethod]
        public void GetSetDescription()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.Description = "Dinner";
            Assert.AreEqual("Dinner", expenseDto.Description);
        }

        [TestMethod]
        public void GetSetAmount()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.Amount = 23;
            Assert.AreEqual(23, expenseDto.Amount);
        }

        [TestMethod]
        public void GetSetCreationDate()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.CreationDate = new DateTime(2020,01,01);
            Assert.AreEqual(new DateTime(2020, 01, 01), expenseDto.CreationDate);
        }

        [TestMethod]
        public void GetSetCategoryDtoID()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.CategoryDtoID = 1;
            Assert.AreEqual(1, expenseDto.CategoryDtoID);
        }

        [TestMethod]
        public void GetSetCategory()
        {
            CategoryDto categoryDto = new CategoryDto();
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.Category = categoryDto;
            Assert.AreEqual(categoryDto, expenseDto.Category);
        }

        [TestMethod]
        public void GetSetCurrencyDtoID()
        {
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.CurrencyDtoID = 1;
            Assert.AreEqual(1, expenseDto.CurrencyDtoID);
        }

        [TestMethod]
        public void GetSetCurrency()
        {
            CurrencyDto currencyDto = new CurrencyDto();
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.Currency = currencyDto;
            Assert.AreEqual(currencyDto, expenseDto.Currency);
        }

    }
}
