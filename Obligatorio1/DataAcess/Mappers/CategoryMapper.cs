using DataAccess.Mappers;
using DataAcess.DBObjects;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAcess.Mappers
{
    class CategoryMapper : IMapper<Category, CategoryDto>

    {
        public CategoryMapper()
        {
        }

        public CategoryDto DomainToDto(Category obj, DbContext context)
        {
            List<KeyWordsDto> KeyWordsDto = new List<KeyWordsDto>();
            foreach (string KeyWord in obj.KeyWords)
            {
                KeyWordsDto.Add(new KeyWordsDto()
                {
                    Value = KeyWord
                });
            };
            return new CategoryDto()
            {
                Name = obj.Name,
                KeyWords= KeyWordsDto
            };
        }

        public Category DtoToDomain(CategoryDto obj, DbContext context)
        {
            List<string> keyWords = new List<string>();
            context.Entry(obj).Collection("KeyWords").Query().Load();
            foreach (KeyWordsDto keyWord in obj.KeyWords)
            {
                keyWords.Add(
                    keyWord.Value
                );
            };
            return new Category()
            {
                Name = obj.Name,
                KeyWords = keyWords
            };
        }
    }
}
