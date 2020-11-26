using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAcess;
using DataAcess.DBObjects;

namespace Test.DataAcessTest
{
    [TestClass]
    public class BudgetCategroyDtoTest
    {
        [TestMethod]
        public void GetSetBudgetCategoryDtoId()
        {
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.BudgetCategoryDtoID = 1;
            Assert.AreEqual(budgetCategoryDto.BudgetCategoryDtoID, 1);
        }

        [TestMethod]
        public void GetSetCategoryDtoID()
        {
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.CategoryDtoID = 1;
            Assert.AreEqual(budgetCategoryDto.CategoryDtoID, 1);
        }

        [TestMethod]
        public void GetSetCategory()
        {
            CategoryDto categoryDto = new CategoryDto();
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.Category = categoryDto;
            Assert.AreEqual(budgetCategoryDto.Category, categoryDto);
        }

        [TestMethod]
        public void GetSetAmount()
        {
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.Amount = 23;
            Assert.AreEqual(budgetCategoryDto.Amount,23);
        }

        [TestMethod]
        public void GetSetBudgetDtoID()
        {
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.BudgetDtoID = 23;
            Assert.AreEqual(budgetCategoryDto.BudgetDtoID, 23);
        }

        [TestMethod]
        public void GetSetBudgetDto()
        {
            BudgetDto budgetDto = new BudgetDto();
            BudgetCategoryDto budgetCategoryDto = new BudgetCategoryDto();
            budgetCategoryDto.BudgetDto = budgetDto;
            Assert.AreEqual(budgetCategoryDto.BudgetDto, budgetDto);
        }

    }
}
