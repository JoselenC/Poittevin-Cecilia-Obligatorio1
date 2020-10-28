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
            String categoryName = "the entertainment";
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
            String categoryName = "entertainment";
            List<string> keyWords = new List<string>() {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            "game room",
            "Park",
            "shopping",
            };
        Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };

        }


        [TestMethod]
        public void CreateCategoryValidNameAndKeyWords()
        {
            String categoryName = "entertainment";
            List<string> keyWords = new List<string>() {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            "game room",
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords);
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            Assert.AreEqual(category.Name, categoryName);
            Assert.AreEqual(category.KeyWords,expectedKeyWord);
        }

       
        [TestMethod]
        public void ToStringOnlyNameFormatValid()
        {
            Category category = new Category { Name = "Test Category"};
            string expectedFormat = "Test Category";
            string actualFormat = category.ToString();
            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void ToStringWithKeywordsFormatValid()
        {
            List<string> keyWords = new List<string>
            {

                "movie theater",
                "theater",
                "departure"
            };
            Category category = new Category { Name = "Test Category",KeyWords = new KeyWord(keyWords) };
            string expectedFormat = "Test Category";
            string actualFormat = category.ToString();
            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void EqualTrueCaseWithoutKeywords() {
            Category category1 = new Category { Name = "Test Category" , KeyWords=new KeyWord() };
            Category category2 = new Category { Name = "Test Category", KeyWords = new KeyWord() };
            Assert.AreEqual(category1, category2);
        }

        [TestMethod]
        public void EqualTrueCaseWithKeywords()
        {
            List<string> keyWords1 = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            Category category1 = new Category { Name = "Test Category", KeyWords = new KeyWord(keyWords1) };

            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = new KeyWord(keyWords2) };

            Assert.AreEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffKeywordsLenght()
        {
            List<string> keyWords1 = new List<string>
            {
                "movie theater",
                "theater",
            };
            Category category1 = new Category { Name = "Test Category", KeyWords = new KeyWord(keyWords1) };

            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = new KeyWord(keyWords2)};

            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffKeywordsValues()
        {
            List<string> keyWords1 = new List<string>
            {
                "movie theater",
                "theater",
                "food"
            };
            Category category1 = new Category { Name = "Test Category", KeyWords= new KeyWord(keyWords1)};
            List<string> keyWords2 = new List<string>
            {
                 "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = new KeyWord(keyWords2)};
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffName()
        {
            Category category1 = new Category { Name = "Test Cate", KeyWords = new KeyWord()};
            Category category2 = new Category { Name = "Test Category",KeyWords = new KeyWord() };
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseNoCategory()
        {
            Category category1 = new Category { Name = "Test Cate", KeyWords = new KeyWord() };
            List<string> keyWords = new List<string>
            {
                 "movie theater",
                "theater",
                "departure"
            };
            Assert.AreNotEqual(category1,keyWords);
        }

        [TestMethod]
        public void ExistThiskeyWordCaseTrue()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord};
            bool exist = category1.ExistThisKey("theater");
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void ExistThiskeyWordCaseFalse()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.ExistThisKey("dinner");
            Assert.IsFalse(exist);
        }

        [TestMethod]
        public void ExistkeyWordInAnotherCategoryCaseTrue()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.ExistKeyWordInAnotherCategory(keyWord);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void ExistkeyWordInAnotherCategoryCaseFalse()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = new KeyWord()};
            bool exist = category1.ExistKeyWordInAnotherCategory(keyWord);
            Assert.IsFalse(exist);
        }

        [TestMethod]
        public void ExistkeyWordInDescriptionCaseTrue()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.ExistKeyWordInDscription("theater");
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void ExistkeyWordInDescriptionCaseFalse()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.ExistKeyWordInDscription("eat");
            Assert.IsFalse(exist);
        }

        [TestMethod]
        public void SameCategoryNameCaseTrue()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.IsSameCategoryName("Test Category");
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void SameCategoryNameCaseFalse()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            bool exist = category1.IsSameCategoryName("Entertainment");
            Assert.IsFalse(exist);
        }

        [TestMethod]
        public void ExistkeyWordInDescriptionArrayCaseTrue()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            String[] description = { "Go", "theater" };
            bool exist = category1.IsKeyWordInDescription(description);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void ExistkeyWordInDescriptionArrayCaseFalse()
        {
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWord };
            String[] description = { "Go", "to", "dinner" };
            bool exist = category1.IsKeyWordInDescription(description);
            Assert.IsFalse(exist);
        }

    }
}