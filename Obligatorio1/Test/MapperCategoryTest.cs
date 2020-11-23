using BusinessLogic;
using DataAcess.DBObjects;
using DataAcess.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class MapperCategoryTest
    {
        [TestMethod]
        public void TestMapperUpdateObject()
        {
            CategoryMapper mapperCategory = new CategoryMapper();
            List<string> newKeywords = new List<string>()
            {
                "key1",
                "key2"
            };
            List<KeyWordsDto> originalkeyWords = new List<KeyWordsDto>()
            {
                new KeyWordsDto(){Value="key1"},
                new KeyWordsDto(){Value="key3"},
            };
            Category newCategory = new Category { Name = "testCategory", KeyWords= newKeywords };

            CategoryDto categoryDto = new CategoryDto()
            {
                Name = "testCategory",
                KeyWords = originalkeyWords
            };

            List<KeyWordsDto> newKeyWordsDto = new List<KeyWordsDto>()
            {
                new KeyWordsDto(){Value="key1"},
                new KeyWordsDto(){Value="key2"},
            };
            CategoryDto ExpectedcategoryDto = new CategoryDto()
            {
                Name = "testCategory",
                KeyWords = newKeyWordsDto
            };

            //CategoryDto ResultCategoryDto = mapperCategory.UpdateDtoObject(categoryDto, newCategory);
            //CollectionAssert.AreEqual(ExpectedcategoryDto.KeyWords, ResultCategoryDto.KeyWords);
        }

    }
}
