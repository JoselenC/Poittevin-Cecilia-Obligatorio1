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
        public void SetKeyWord()
        {
            KeyWord keyWord = new KeyWord() { Value = "movie theater" };
            Assert.AreEqual("movie theater", keyWord.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidKeyWord))]
        public void SetEmptyKeyWord()
        {
            KeyWord keyWord = new KeyWord() { Value = "" };
        }

        [TestMethod]
        public void EqualsKeyWordCaseTrue()
        {
            KeyWord keyWord = new KeyWord() { Value = "movie" };
            KeyWord keyWord2 = new KeyWord() { Value = "movie" };
            Assert.AreEqual(keyWord, keyWord2);
        }

        [TestMethod]
        public void EqualsKeyWordCaseEquealsString()
        {
            KeyWord keyWord = new KeyWord() { Value = "movie" };
            string value = "movie";
            Assert.AreEqual(keyWord, value);
        }


        [TestMethod]
        public void EqualsKeyWordCaseFalse()
        {
            KeyWord keyWord = new KeyWord() { Value = "movie" };
            KeyWord keyWord2 = new KeyWord() { Value = "food" };
            Assert.AreNotEqual(keyWord, keyWord2);
        }

        [TestMethod]
        public void EqualsKeyWordCaseFalseObj()
        {
            KeyWord keyWord = new KeyWord() { Value = "movie" };
            Currency currency = new Currency();
            Assert.AreNotEqual(keyWord,currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidKeyWord))]
        public void KeyWordsConstructorCaseEmptyString()
        {
            KeyWord keyWord = new KeyWord("", new List<string>());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsCategory))]
        public void KeyWordsConstructorRepetedKeyWord()
        {
            List<string> keyWords = new List<string>() { "movie" };
            KeyWord keyWord = new KeyWord("movie", keyWords);

        }

        [TestMethod]
        public void KeyWordsConstructor()
        {
            List<string> keyWords = new List<string>() { "food" };
            KeyWord keyWord = new KeyWord("movie", keyWords);
            KeyWord keyWord2 = new KeyWord() { Value = "movie" };
            Assert.AreEqual(keyWord, keyWord2);
        }

    }
}
