using System;
using System.Collections.Generic;
using DataAcess.DBObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataAcessTest.DBObjectsTest
{
    [TestClass]
    public class CategoryDtoTest
    {
        [TestMethod]
        public void SetGetCategoryDtoId()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.CategoryDtoID = 1;
            Assert.AreEqual(1, categoryDto.CategoryDtoID);
        }

        [TestMethod]
        public void SetGetName()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.Name = "food";
            Assert.AreEqual("food", categoryDto.Name);
        }

        [TestMethod]
        public void SetGetKeyWords()
        {
            List<KeyWordsDto> keyWords = new List<KeyWordsDto>();
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.KeyWords = keyWords;
            Assert.AreEqual(keyWords, categoryDto.KeyWords);
        }
    }
}
