using System;
using System.Collections.Generic;
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
            Category category = new Category { Name = "testCategory" };
            double amount = 100;
            BudgetCategory budgetCategory = new BudgetCategory { Category = category, Amount = amount };
            Assert.AreEqual(budgetCategory.Category, category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateBudgetCategoryNullCategory()
        {
            double amount = 100;
            BudgetCategory budgetCategory = new BudgetCategory {Category=null, Amount = amount };
        }

        [TestMethod]
        public void TestCreateBudgetCategoryAmountWithDecimals()
        {
            Category category = new Category { Name = "testCategory" };
            double amount = 100.23;
            BudgetCategory budgetCategory = new BudgetCategory { Category = category, Amount = amount };
            Assert.AreEqual(amount, budgetCategory.Amount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetCategoryAmountWithNegativeValue()
        {
            Category category = new Category { Name = "testCategory" };
            double amount = -1;
            BudgetCategory budgetCategory = new BudgetCategory { Category = category, Amount = amount };
        }

        [TestMethod]
        public void TestEqualsTrueCase()
        {
            Category category1 = new Category { Name = "testCategory", KeyWords = new List<string>() };
            BudgetCategory budgetCategory1 = new BudgetCategory { Category = category1, Amount =0};

            Category category2 = new Category { Name = "testCategory", KeyWords = new List<string>() };
            BudgetCategory budgetCategory2 = new BudgetCategory { Category = category2, Amount = 0};

            Assert.AreEqual(budgetCategory1, budgetCategory2);

        }
        [TestMethod]
        public void TestEqualsFalseCaseDiffAmount()
        {
            Category category1 = new Category { Name = "testCategory",KeyWords=new List<string>() };
            BudgetCategory budgetCategory1 = new BudgetCategory { Category = category1, Amount = 0 };

            Category category2 = new Category { Name = "testCategory", KeyWords = new List<string>() };
            BudgetCategory budgetCategory2 = new BudgetCategory { Category = category2, Amount = 100 };

            Assert.AreNotEqual(budgetCategory1, budgetCategory2);

        }

        [TestMethod]
        public void TestEqualsFalseCaseDiffCategory()
        {
            Category category1 =new Category { Name = "testCategory", KeyWords = new List<string>() };
            BudgetCategory budgetCategory1 =  new BudgetCategory { Category = category1, Amount = 0 };

            Category category2 = new Category { Name = "WrongCategory", KeyWords = new List<string>() };
            BudgetCategory budgetCategory2 =  new BudgetCategory { Category = category2, Amount = 0 };

            Assert.AreNotEqual(budgetCategory1, budgetCategory2);

        }

        [TestMethod]
        public void TestEqualsFalseCaseDiffCategoryKeyWords()
        {
            Category category1 = new Category { Name = "testCategory", KeyWords = new List<string>() { "Key1", "Key2" } };
            BudgetCategory budgetCategory1 = new BudgetCategory { Category = category1, Amount = 0 };

            Category category2 = new Category { Name = "WrongCategory", KeyWords = new List<string>() { "Key1", "Key3" } };
            BudgetCategory budgetCategory2 = new BudgetCategory { Category = category2, Amount = 0 };

            Assert.AreNotEqual(budgetCategory1, budgetCategory2);

        }
    }
}
