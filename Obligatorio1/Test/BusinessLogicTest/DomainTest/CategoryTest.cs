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
            Category category = new Category{Name=categoryName};
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameDigitCategory), "")]
        public void CreateCategoryInvalidNameNumbers()
        {
            String categoryName = "9999";
            Category category = new Category { Name = categoryName };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidLengthName()
        {
            String categoryName = "the entertainment";
            Category category = new Category { Name = categoryName };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidNameLengthCategory), "")]
        public void CreateCategoryInvalidShortName()
        {
            String categoryName = "la";
            Category category = new Category { Name = categoryName };
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
            Category category = new Category { Name = categoryName, KeyWords = keyWords };

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
            Category category = new Category { Name = "Test Category",KeyWords = keyWords };
            string expectedFormat = "Test Category";
            string actualFormat = category.ToString();
            Assert.AreEqual(expectedFormat, actualFormat);

        }

        [TestMethod]
        public void EqualTrueCaseWithoutKeywords() {
            Category category1 = new Category { Name = "Test Category" };
            Category category2 = new Category { Name = "Test Category" };
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords1};

            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = keyWords2 };

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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords1};

            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = keyWords2};

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
            Category category1 = new Category { Name = "Test Category", KeyWords= keyWords1};
            List<string> keyWords2 = new List<string>
            {
                 "movie theater",
                "theater",
                "departure"
            };
            Category category2 = new Category { Name = "Test Category", KeyWords = keyWords2};
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseCaseDiffName()
        {
            Category category1 = new Category { Name = "Test Cate"};
            Category category2 = new Category { Name = "Test Category"};
            Assert.AreNotEqual(category1, category2);
        }

        [TestMethod]
        public void EqualFalseNoCategory()
        {
            Category category1 = new Category { Name = "Test Cate"};
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords };
            bool exist = category1.CategoryContainKeyword("theater");
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords };
            bool exist = category1.CategoryContainKeyword("dinner");
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords };
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords };
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
            Category category1 = new Category { Name = "Test Category", KeyWords = keyWords };
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
            Category category1 = new Category(){ Name = "Test Category", KeyWords = keyWords };
            String[] description = { "Go", "to", "dinner" };
            bool exist = category1.IsKeyWordInDescription(description);
            Assert.IsFalse(exist);
        }

    }
}