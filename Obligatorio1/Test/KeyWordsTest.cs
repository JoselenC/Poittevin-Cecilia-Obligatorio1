using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class KeyWordsTest
    {
        //[TestMethod]
        //[ExpectedException(typeof(ExcepcionInvalidKeyWordsLengthCategory))]
        //public void SetKeyWordInvalidLength()
        //{
        //    List<string> keyWords = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    "bookstore",
        //    "jugeteria",
        //    "shopping",
        //    "skating",
        //    "casino",
        //    "game room",
        //    "Park",
        //    "shopping"

        //    };
        //    KeyWord keyWord = new KeyWord(keyWords);
        //}

        //[TestMethod]
        //public void SetKeyWordValidCase()
        //{
        //    List<string> keyWords = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    "bookstore",
        //    "jugeteria",
        //    "shopping",
        //    "skating",
        //    "casino",
        //    "game room",
        //    };
        //    KeyWord expectedKeyWord = new KeyWord(keyWords);
        //    KeyWord keyWord = new KeyWord(keyWords);            
        //    Assert.AreEqual(expectedKeyWord, keyWord);
        //}

        //[TestMethod]
        //public void EqualsKeyWordCaseTrue()
        //{
        //    List<string> keyWords = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    "bookstore",
        //    "jugeteria",
        //    "shopping",
        //    "skating",
        //    "casino",
        //    "game room",
        //    };
        //    KeyWord expectedKeyWord = new KeyWord(keyWords);
        //    KeyWord keyWord = new KeyWord(keyWords);
        //    Assert.IsTrue(expectedKeyWord.Equals(keyWord));
        //}


        //[TestMethod]
        //public void EqualsKeyWordCaseFalse()
        //{
        //    List<string> keyWords = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    "bookstore",
        //    "jugeteria",
        //    "shopping",
        //    "skating",
        //    "casino",
        //    "game room",
        //    };
        //    List<string> keyWords2 = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    };
        //    KeyWord expectedKeyWord = new KeyWord(keyWords);
        //    KeyWord keyWord = new KeyWord(keyWords2);
        //    Assert.IsFalse(expectedKeyWord.Equals(keyWord));
        //}

        //[TestMethod]
        //public void EqualsKeyWordCaseNoKeyWord()
        //{
        //    List<string> keyWords = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    "bookstore",
        //    "jugeteria",
        //    "shopping",
        //    "skating",
        //    "casino",
        //    "game room",
        //    };
        //    List<string> keyWords2 = new List<string>()
        //    {
        //    "movie theater",
        //    "theater",
        //    "departure",
        //    };
        //    KeyWord expectedKeyWord = new KeyWord(keyWords);
        //    KeyWord keyWord = new KeyWord(keyWords2);
        //    Assert.IsFalse(expectedKeyWord.Equals(keyWords));
        //}

    }
}
