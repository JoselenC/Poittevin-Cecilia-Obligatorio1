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
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryEmptyName()
        {
            String categoryName = "";
            List<string> keyWords = new List<string>();
            new Category(categoryName, keyWords);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameDigitCategory), "")]
        public void CreateCategoryInvalidName()
        {
            String categoryName = "9999";
            List<string> keyWords = new List<string>();
            new Category(categoryName, keyWords);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidName2()
        {
            String categoryName = "entretenimientos";
            List<string> keyWords = new List<string>();
            new Category(categoryName, keyWords);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidName3()
        {
            String categoryName = "la";
            List<string> keyWords = new List<string>();
            new Category(categoryName, keyWords);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidKeyWordsLengthCategory), "")]
        public void CreateCategoryInvalidKeyWords()
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
            keyWords.Add("shopping");
            new Category(categoryName, keyWords);

        }


        [TestMethod]
        public void CreateCategory()
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

            Category category = new Category(categoryName, keyWords);

            Assert.AreEqual(category.Name, categoryName);
            Assert.AreEqual(category.KeyWords, keyWords);
        }

        [TestMethod]
        public void CreateCategory2()
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

        [TestMethod]

        public void ToStringOnlyNameFormatValid()
        {
            Category category = new Category("Test Categoria");
            string expectedFormat = "Test Categoria";

            string actualFormat = category.ToString();

            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void ToStringWithKeywordsFormatValid()
        {
            List<string> keyWords = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category = new Category("Test Categoria", keyWords);
            string expectedFormat = "Test Categoria";

            string actualFormat = category.ToString();

            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void EqualTrueCaseWithoutKeywords() {

            Category category1 = new Category("Test Categoria");
            Category category2 = new Category("Test Categoria");

            Assert.AreEqual(category1, category2);
        }

        [TestMethod]
        public void EqualTrueCaseWithKeywords()
        {
            List<string> keyWords1 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category1 = new Category("Test Categoria", keyWords1);

            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category("Test Categoria", keyWords2);

            Assert.AreEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffKeywordsLenght()
        {
            List<string> keyWords1 = new List<string>
            {
                "cine",
                "teatro",
            };
            Category category1 = new Category("Test Categoria", keyWords1);

            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category("Test Categoria", keyWords2);

            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffKeywordsValues()
        {
            List<string> keyWords1 = new List<string>
            {
                "cine",
                "teatro",
                "comida"
            };
            Category category1 = new Category("Test Categoria", keyWords1);

            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category("Test Categoria", keyWords2);

            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffName()
        {

            Category category1 = new Category("Test Cate");
            Category category2 = new Category("Test Categoria");

            Assert.AreNotEqual(category1, category2);
        }
    }
}