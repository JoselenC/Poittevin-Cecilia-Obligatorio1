using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryEmptyName()
        {
            String categoryName = "";
            Category emptyCategory = new Category(categoryName);
            

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName()
        {
            String categoryName = "9999";
            Category emptyCategory = new Category(categoryName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName2()
        {
            String categoryName = "entretenimientos";
            Category emptyCategory = new Category(categoryName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName3()
        {
            String categoryName = "la";
            Category emptyCategory = new Category(categoryName);
        }

        [TestMethod]
        public void createCategory()
        {
            String categoryName = "food";
            Category emptyCategory = new Category(categoryName);
            Assert.AreEqual(emptyCategory.name, categoryName);
        }

        [TestMethod]
        public void createCategory2()
        {
            String categoryName = "rent apartment 2";
            Category emptyCategory = new Category(categoryName);
            Assert.AreEqual(emptyCategory.name, categoryName);
        }

    }
}
