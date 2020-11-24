using BusinessLogic.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CategoryController
    {
        private IManageRepository repository;

        public CategoryController(IManageRepository vRepository)
        {
            repository = vRepository;
        }

        public void AlreadyExistKeyWordInAnoterCategory(string pKeyWord)
        {
            List<Category> categories = repository.GetCategories();
            foreach (Category category in categories)
            {
                if (category.CategoryContainKeyword(pKeyWord))
                    throw new ExcepcionInvalidRepeatedKeyWordsInAnotherCategory();
            }
        }

        public Category FindCategoryByName(string categoryName)
        {
            return repository.FindCategoryByName(categoryName);
        }

        private void AddCategoryInAllBudgets(Category category)
        {
            foreach (Budget budget in repository.GetBudgets())
            {
                budget.AddBudgetCategory(category);
            }
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            Category category = repository.SetCategory(vName, vKeyWords);
            AddCategoryInAllBudgets(category);
            return category;
        } 
        
        public Category UpdateCategory(Category oldCategory, Category newCategory)
        {
            newCategory = repository.UpdateCategory(oldCategory, newCategory);          
            return newCategory;
        }

        private List<Expense> GetExpenses()
        {
            return repository.GetExpenses();
        }

        private void EditCategoryInAllExpenses(Category category, Category newCategory)
        {
            List<Expense> expenses = GetExpenses();
            foreach (Expense expense in expenses)
            {
                if (expense.Category.Equals(category))
                    expense.Category = newCategory;
            }
        }

        private void EditCategoryInAllBudgets(Category oldCategory, Category newCategory)
        {
            List<Budget> budgets = repository.GetBudgets();
            foreach (Budget budget in budgets)
            {
                budget.EditBudgetCategory(oldCategory, newCategory);
            }
        }

        public void EditCategory(Category oldCategory, string newName, List<string> newKeywords)
        {
            
        }

        public List<Category> GetCategories()
        {
            return repository.GetCategories();
        }      

        public void SetCategory(object categoryName, object keyWords)
        {
            throw new NotImplementedException();
        }
    }

}