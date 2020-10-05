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
            Category emptyCategory = new Category(categoryName, keyWords);
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
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidKeyWords()
        {
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            keyWords.Add("parque");
            keyWords.Add("piscina");
            Category category = new Category(categoryName, keyWords);

        }

        [TestMethod]
        public void createCategory()
        {
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            Category category = new Category(categoryName, keyWords);
            Assert.AreEqual(category.Name, categoryName);
            Assert.AreEqual(category.KeyWords, keyWords);
        }

        [TestMethod]
        public void createCategory2()
        {
            String categoryName = "rent apartment";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            keyWords.Add("parque");
            Category category = new Category(categoryName, keyWords);
            Assert.AreEqual(category.Name, categoryName);
            Assert.AreEqual(category.KeyWords, keyWords);
        }

    }
}