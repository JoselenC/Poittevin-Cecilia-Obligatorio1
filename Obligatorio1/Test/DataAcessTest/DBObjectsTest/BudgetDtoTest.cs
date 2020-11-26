using System;
using System.Collections.Generic;
using DataAcess.DBObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataAcessTest.DBObjectsTest
{
    [TestClass]
    public class BudgetDtoTest
    {
        [TestMethod]
        public void GetSetBudgetDtoId()
        {
            BudgetDto budgetDto = new BudgetDto();
            budgetDto.BudgetDtoID = 1;
            Assert.AreEqual(1, budgetDto.BudgetDtoID);
        }

        [TestMethod]
        public void GetSetMonth()
        {
            BudgetDto budgetDto = new BudgetDto();
            budgetDto.Month = 1;
            Assert.AreEqual(1, budgetDto.Month);
        }

        [TestMethod]
        public void GetSetTotalAmount()
        {
            BudgetDto budgetDto = new BudgetDto();
            budgetDto.TotalAmount = 1;
            Assert.AreEqual(1, budgetDto.TotalAmount);
        }

        [TestMethod]
        public void GetSetYear()
        {
            BudgetDto budgetDto = new BudgetDto();
            budgetDto.Year = 2020;
            Assert.AreEqual(2020, budgetDto.Year);
        }

        [TestMethod]
        public void GetSetBudgetCategories()
        {
            List<BudgetCategoryDto> budgetCategoryDto = new List<BudgetCategoryDto>();
            BudgetDto budgetDto = new BudgetDto();
            budgetDto.BudgetCategories = budgetCategoryDto;
            Assert.AreEqual(budgetCategoryDto, budgetDto.BudgetCategories);
        }
    }
}
