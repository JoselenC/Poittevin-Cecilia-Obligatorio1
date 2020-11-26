using DataAccess.Mappers;
using DataAcess.DBObjects;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace DataAcess.Mappers
{
    public class CategoryMapper : IMapper<Category, CategoryDto>

    {
        public CategoryMapper()
        {
        }
        private List<KeyWordsDto> createKeyWordsDto(List<string> keyWords, DbContext context)
        {
            List<KeyWordsDto> KeyWordsDto = new List<KeyWordsDto>();
            DbSet<KeyWordsDto> KeyWordsSet = context.Set<KeyWordsDto>();                        
            foreach (string KeyWord in keyWords)
            {
                KeyWordsDto keyWordsDto = KeyWordsSet.Where(x => x.Value == KeyWord).FirstOrDefault();
                if(keyWordsDto is null)
                    keyWordsDto = new KeyWordsDto()
                    {
                        Value = KeyWord
                    };
                KeyWordsDto.Add(keyWordsDto);
            };
            return KeyWordsDto;
        }

        public CategoryDto DomainToDto(Category obj, DbContext context)
        {
            DbSet<CategoryDto> CategorySet = context.Set<CategoryDto>();
            try
            {
                CategoryDto categoryDto = CategorySet.Where(x => x.Name == obj.Name).FirstOrDefault();
                if (categoryDto is null)
                    categoryDto = new CategoryDto()
                    {
                        Name = obj.Name,
                    };

                categoryDto.KeyWords = createKeyWordsDto(obj.KeyWords, context);
                return categoryDto;
            }
            catch (TargetException)
            {
                throw new ExceptionUnableToSaveData();
            }
        }

        public Category DtoToDomain(CategoryDto obj, DbContext context)
        {
            List<string> keyWords = new List<string>();
            context.Entry(obj).Collection("KeyWords").Query().Load();
            if(!(obj.KeyWords is null))
            {
                foreach (KeyWordsDto keyWord in obj.KeyWords)
                {
                    keyWords.Add(
                        keyWord.Value
                    );
                };
            }
            return new Category()
            {
                Name = obj.Name,
                KeyWords = keyWords
            };
        }

        public CategoryDto UpdateDtoObject(CategoryDto objToUpdate, Category updatedObject, DbContext context)
        {
            objToUpdate.Name = updatedObject.Name;
            if (objToUpdate.KeyWords == null)
            {
                objToUpdate.KeyWords = new List<KeyWordsDto>();
            }
            List<KeyWordsDto> diffListOldValues = objToUpdate.KeyWords.Where(x => updatedObject.KeyWords.Contains(x.Value)).ToList();
            List<string> diffListNewValues = updatedObject.KeyWords.Where(x => !objToUpdate.KeyWords.Contains(new KeyWordsDto() { Value = x })).ToList();
            diffListOldValues.AddRange(diffListNewValues.Select(x => new KeyWordsDto() { Value = x }));
            List<KeyWordsDto> keyWordsToDelete = objToUpdate.KeyWords.Where(x => !diffListOldValues.Contains(x)).ToList();
            foreach (KeyWordsDto keyWordsDto in keyWordsToDelete)
            {
               context.Entry(keyWordsDto).State = EntityState.Deleted;
            };
            objToUpdate.KeyWords = diffListOldValues;
            return objToUpdate;
        }
    }
}
