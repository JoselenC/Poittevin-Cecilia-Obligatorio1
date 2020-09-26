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
            new BudgetCategory(category, amount);
        }

        [TestMethod]
        public void TestCreateBudgetCategoryNullCategory()
        {
            double amount = 100;
            new BudgetCategory(null, amount);
        }

        [TestMethod]
        public void TestCreateBudgetCategoryAmountWithDecimals()
        {
            double amount = 100.23;
            new BudgetCategory(null, amount);
        }
    }
}
