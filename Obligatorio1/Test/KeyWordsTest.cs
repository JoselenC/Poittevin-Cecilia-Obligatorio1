using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class KeyWordsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidKeyWordsLengthCategory))]
        public void SetKeyWordInvalidLength()
        {
            List<string> keyWords = new List<string>()
            {
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
            
            };
            KeyWord keyWord = new KeyWord(keyWords);
            keyWords.Add("shopping");
            keyWord.SetKeyWord(keyWord);
        }

        [TestMethod]
        public void SetKeyWordValidCase()
        {
            List<string> keyWords = new List<string>()
            {
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
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.SetKeyWord(keyWord);
            Assert.AreEqual(expectedKeyWord, keyWord);
        }

        [TestMethod]
        public void EqualsKeyWordCaseTrue()
        {
            List<string> keyWords = new List<string>()
            {
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
            KeyWord keyWord = new KeyWord(keyWords);
            Assert.IsTrue(expectedKeyWord.Equals(keyWord));
        }


        [TestMethod]
        public void EqualsKeyWordCaseFalse()
        {
            List<string> keyWords = new List<string>()
            {
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
            List<string> keyWords2 = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords);
            KeyWord keyWord = new KeyWord(keyWords2);
            Assert.IsFalse(expectedKeyWord.Equals(keyWord));
        }

        [TestMethod]
        public void EqualsKeyWordCaseNoKeyWord()
        {
            List<string> keyWords = new List<string>()
            {
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
            List<string> keyWords2 = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords);
            KeyWord keyWord = new KeyWord(keyWords2);
            Assert.IsFalse(expectedKeyWord.Equals(keyWords));
        }

        [TestMethod]
        public void ContieneCaseTrue()
        {
            List<string> keyWords = new List<string>()
            {
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
            string description = "movie theater";
            KeyWord keyWord = new KeyWord(keyWords);
            Assert.IsTrue(keyWord.DescriptionContainAPartOfDescription(description));
        }

        [TestMethod]
        public void ContieneCaseFalse()
        {
            List<string> keyWords = new List<string>()
            {
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
            string description = "food";
            KeyWord keyWord = new KeyWord(keyWords);
            Assert.IsFalse(keyWord.DescriptionContainAPartOfDescription(description));
        }


        [TestMethod]
        public void ExistKeyWordAnotherCategoryCaseFalse()
        {
            List<string> keyWords = new List<string>()
            {
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
            List<string> keyWords2 = new List<string>()
            {
            "cena",
            };
            KeyWord keyWord = new KeyWord(keyWords);
            KeyWord keyWord2 = new KeyWord(keyWords2);
            Category category = new Category { Name = "entertainment", KeyWords = keyWord };
            bool exist = true;
            Assert.IsFalse(keyWord.ExistKeyWords(keyWord2));
        }

        [TestMethod]
        public void ExistKeyWordAnotherCategoryCaseTrue()
        {
            List<string> keyWords = new List<string>()
            {
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
            List<string> keyWords2 = new List<string>()
            {
            "casino",
            "cine",
            "cena"
            };
            KeyWord keyWord = new KeyWord(keyWords);
            KeyWord keyWord2 = new KeyWord(keyWords2);
            Category category = new Category { Name = "entertainment", KeyWords = keyWord };
            bool exist =true;
            Assert.IsTrue(keyWord.ExistKeyWords(keyWord2));
        }


        [TestMethod]
        public void ExistKeyCaseTrue()
        {
            List<string> keyWords = new List<string>()
            {
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
            KeyWord keyWord = new KeyWord(keyWords);
            Category category = new Category { Name = "entertainment", KeyWords = keyWord };
            bool exist = false;
            Assert.IsTrue(keyWord.ExistThisKey("movie theater"));
        }


        [TestMethod]
        public void ExistKeyCaseFalse()
        {
            List<string> keyWords = new List<string>()
            {
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
            KeyWord keyWord = new KeyWord(keyWords);
            Category category = new Category { Name = "entertainment", KeyWords = keyWord };
            bool exist = false;
            Assert.IsFalse(keyWord.ExistThisKey("food"));
        }

        [TestMethod]
        public void AsignKeyWordToList()
        {
            List<string> keyWords = new List<string>()
            {
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
            KeyWord keyWord = new KeyWord(keyWords);
            List<string> keyWords2 = new List<string>();
            keyWords2 = keyWord.AsignKeyWordToList(keyWord);
            Assert.AreEqual(keyWords, keyWords2);
        }

        [TestMethod]
        public void AddValidKeyWord()
        {
            List<string> keyWords = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            };
            List<string> keyWords2 = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            "game room"
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords2);
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.AddKeyWord("game room");
            Assert.AreEqual(expectedKeyWord, keyWord);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidKeyWord))]
        public void AddEmptyKeyWord()
        {
            List<string> keyWords = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords);
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.AddKeyWord("");
            Assert.AreEqual(expectedKeyWord, keyWord);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsCategory))]
        public void AddRepetedKeyWord()
        {
            List<string> keyWords = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            };
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.AddKeyWord("casino");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidKeyWordsLengthCategory))]
        public void AddKeyWordInvalidLength()
        {
            List<string> keyWords = new List<string>()
            {
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
            };
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.AddKeyWord("keyword");
        }

        [TestMethod]
        public void DeleteKeyWord()
        {
            List<string> keyWords = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating",
            "casino",
            };
            List<string> keyWords2 = new List<string>()
            {
            "movie theater",
            "theater",
            "departure",
            "bookstore",
            "jugeteria",
            "shopping",
            "skating"
            };
            KeyWord expectedKeyWord = new KeyWord(keyWords2);
            KeyWord keyWord = new KeyWord(keyWords);
            keyWord.DeleteKeyWord("casino");
            Assert.AreEqual(expectedKeyWord, keyWord);
        }


    }
}
