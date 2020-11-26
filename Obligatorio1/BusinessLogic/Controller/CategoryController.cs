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
            BudgetController budgetController = new BudgetController(repository);

            if (AlreadyExistTheKeyWordsInAnoterCategory(category.KeyWords))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            if (AlreadyExistCategoryName(category.Name))
                throw new ExcepcionInvalidRepeatedNameCategory();

            repository.Categories.Add(category);
            budgetController.AddCategoryInAllBudgets(category);
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            Category category = new Category { Name = vName, KeyWords = vKeyWords };
            AddCategory(category);
            return category;
        }
        public Category SetCategory(Category category)
        {
            AddCategory(category);
            return category;
        }

        public void UpdateCategory(Category oldCategory, Category newCategory)
        {
            repository.Categories.Update(oldCategory, newCategory);  
        }        

        public List<Category> GetCategories()
        {
            return repository.Categories.Get();
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