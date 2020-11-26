using System;
using DataAcess.DBObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataAcessTest.DBObjectsTest
{
    [TestClass]
    public class KeyWordsDtoTest
    {
        [TestMethod]
        public void GetSetKeyWordsDtoID()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.KeyWordsDtoID = 1;
            Assert.AreEqual(1, keyWordsDto.KeyWordsDtoID);
        }

        [TestMethod]
        public void GetSetValue()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.Value = "movie";
            Assert.AreEqual("movie", keyWordsDto.Value);
        }

        [TestMethod]
        public void GetSetCategoryDtoID()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.CategoryDtoID = 2;
            Assert.AreEqual(2, keyWordsDto.CategoryDtoID);
        }

        [TestMethod]
        public void GetSetCategoryDto()
        {
            CategoryDto categoryDto = new CategoryDto();
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.CategoryDto = categoryDto;
            Assert.AreEqual(categoryDto, keyWordsDto.CategoryDto);
        }

        [TestMethod]
        public void EqualCaseTrue()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.Value = "movie";
            Assert.AreEqual(keyWordsDto, keyWordsDto);
        }

        [TestMethod]
        public void EqualCaseFalseDiffObj()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.Value = "movie";
            CurrencyDto currency = new CurrencyDto();
            Assert.AreNotEqual(keyWordsDto, currency);
        }

        [TestMethod]
        public void EqualCaseFalseDiffValue()
        {
            KeyWordsDto keyWordsDto = new KeyWordsDto();
            keyWordsDto.Value = "movie";
            KeyWordsDto keyWordsDto2 = new KeyWordsDto();
            keyWordsDto.Value = "movies";
            Assert.AreNotEqual(keyWordsDto, keyWordsDto2);
        }

    }
}
