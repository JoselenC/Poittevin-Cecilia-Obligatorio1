using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetCategoryTest
    {
        [TestMethod]
        public void TestCreateBudgetCategory()
        {
            Category category = new Category("testCategory");
            double amount = 100;
            BudgetCategory budgetCategory =  new BudgetCategory(category, amount);
            Assert.AreEqual(budgetCategory.Category, category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateBudgetCategoryNullCategory()
        {
            double amount = 100;
            new BudgetCategory(null, amount);
        }

        [TestMethod]
        public void TestCreateBudgetCategoryAmountWithDecimals()
        {
            Category category = new Category("testCategory");
            double amount = 100.23;
            BudgetCategory budgetCategory = new BudgetCategory(category, amount);
            Assert.AreEqual(amount, budgetCategory.Amount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetCategoryAmountWithNegativeValue()
        {
            Category category = new Category("testCategory");
            double amount = -1;
            new BudgetCategory(category, amount);
        }
    }
}
