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
            Category category = new Category{Name=categoryName, KeyWords=new KeyWord(keyWords)};
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameDigitCategory), "")]
        public void CreateCategoryInvalidNameNumbers()
        {
            String categoryName = "9999";
            List<string> keyWords = new List<string>();
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidLengthName()
        {
            String categoryName = "entretenimientos";
            List<string> keyWords = new List<string>();
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidShortName()
        {
            String categoryName = "la";
            List<string> keyWords = new List<string>();
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidKeyWordsLengthCategory), "")]
        public void CreateCategoryInvalidLengthKeyWords()
        {
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>() {
            "cine",
            "teatro",
            "salida",
            "libreria",
            "jugeteria",
            "shopping",
            "patinaje",
            "casino",
            "sala de juego",
            "parque",
            "shopping",
            };
        Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };

        }


        [TestMethod]
        public void CreateCategoryValidNameAndKeyWords()
        {
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>() { 
            "cine",
            "teatro",
            "salida",
            "libreria",
            "jugeteria",
            "shopping",
            "patinaje",
            "casino",
            "sala de juego",
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords);
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            Assert.AreEqual(category.Name, categoryName);
            Assert.AreEqual(category.KeyWords,expectedKeyWord);
        }

       
        [TestMethod]
        public void ToStringOnlyNameFormatValid()
        {
            Category category = new Category { Name = "Test Categoria"};
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
            Category category = new Category { Name = "Test Categoria",KeyWords = new KeyWord(keyWords) };
            string expectedFormat = "Test Categoria";
            string actualFormat = category.ToString();
            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void EqualTrueCaseWithoutKeywords() {
            Category category1 = new Category { Name = "Test Categoria" , KeyWords=new KeyWord() };
            Category category2 = new Category { Name = "Test Categoria", KeyWords = new KeyWord() };
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
            Category category1 = new Category { Name = "Test Categoria", KeyWords = new KeyWord(keyWords1) };

            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category { Name = "Test Categoria", KeyWords = new KeyWord(keyWords2) };

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
            Category category1 = new Category { Name = "Test Categoria", KeyWords = new KeyWord(keyWords1) };

            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category { Name = "Test Categoria", KeyWords = new KeyWord(keyWords2)};

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
            Category category1 = new Category { Name = "Test Categoria", KeyWords= new KeyWord(keyWords1)};
            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Category category2 = new Category { Name = "Test Categoria", KeyWords = new KeyWord(keyWords2)};
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffName()
        {
            Category category1 = new Category { Name = "Test Cate", KeyWords = new KeyWord()};
            Category category2 = new Category { Name = "Test Categoria",KeyWords = new KeyWord() };
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseNoCategory()
        {
            Category category1 = new Category { Name = "Test Cate", KeyWords = new KeyWord() };
            List<string> keyWords = new List<string>
            {
                "cine",
                "teatro",
                "salida"
            };
            Assert.AreNotEqual(category1,keyWords);
        }
    }
}