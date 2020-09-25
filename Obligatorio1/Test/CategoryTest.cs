using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

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
            List<string> keyWords = new List<string>();
            Category emptyCategory = new Category(categoryName,keyWords);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName()
        {
            String categoryName = "9999";
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
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
            String categoryName = "rent apartment";
            Category emptyCategory = new Category(categoryName);
            Assert.AreEqual(emptyCategory.name, categoryName);
        }

    }
}
