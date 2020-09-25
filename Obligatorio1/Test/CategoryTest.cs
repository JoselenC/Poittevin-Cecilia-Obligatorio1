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
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName3()
        {
            String categoryName = "la";
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
        }

        [TestMethod]
        public void createCategory()
        {
            String categoryName = "food";
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
            Assert.AreEqual(category.name, categoryName);
        }

        [TestMethod]
        public void createCategory2()
        {
            String categoryName = "rent apartment";
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
            Assert.AreEqual(category.name, categoryName);
        }

    }
}
