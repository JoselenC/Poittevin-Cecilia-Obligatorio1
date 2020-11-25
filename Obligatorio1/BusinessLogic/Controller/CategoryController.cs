using BusinessLogic.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CategoryController
    {
        private ManagerRepository repository;

        public CategoryController(ManagerRepository vRepository)
        {
            repository = vRepository;
        }

        public void AlreadyExistKeyWordInAnoterCategory(string pKeyWord)
        {
            List<Category> categories = GetCategories();
            foreach (Category category in categories)
            {
                if (category.CategoryContainKeyword(pKeyWord))
                    throw new ExcepcionInvalidRepeatedKeyWordsInAnotherCategory();
            }
        }

        public Category FindCategoryByName(string categoryName)
        {
            try
            {
                return repository.Categories.Find(e => e.IsSameCategoryName(categoryName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCategoryByName();
            }
        }

        private bool AlreadyExistTheKeyWordsInAnoterCategory(List<string> pkeyWords)
        {
            foreach (Category category in GetCategories())
            {
                foreach (string keyWord in pkeyWords)
                {
                    if (category.CategoryContainKeyword(keyWord))
                        return true;
                }
            }
            return false;
        }
        private bool AlreadyExistCategoryName(string name)
        {
            foreach (Category category in GetCategories())
            {
                if (category.Name == name)
                    return true;
            }
            return false;
        }

        private void AddCategory(Category category)
        {
            if (AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            if (AlreadyExistCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();
            repository.Categories.Add(category);
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            BudgetController budgetController = new BudgetController(repository);
            Category category = new Category { Name = vName, KeyWords = vKeyWords };
            AddCategory(category);
            budgetController.AddCategoryInAllBudgets(category);
            return category;
        } 
        
        public Category UpdateCategory(Category oldCategory, Category newCategory)
        {
            newCategory = repository.Categories.Update(oldCategory, newCategory);          
            return newCategory;
        }

        public void EditCategory(Category oldCategory, string newName, List<string> newKeywords)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            return repository.Categories.Get();
        }      

        public void SetCategory(object categoryName, object keyWords)
        {
            throw new NotImplementedException();
        }

        private Category FindCategoryByDescription(string[] descriptionArray)
        {
            Category category = null;
            foreach (Category vCategory in GetCategories())
            {
                if (vCategory.IsKeyWordInDescription(descriptionArray))
                {
                    if (!(category is null))
                        throw new NoAsignCategoryByDescriptionExpense();
                    category = vCategory;
                }
            }
            if (category is null)
                throw new NoAsignCategoryByDescriptionExpense();
            return category;
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            string[] descriptionArray = vDescription.Split(' ');
            return FindCategoryByDescription(descriptionArray);
        }
    }

}