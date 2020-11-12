using BusinessLogic.Repository;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CategoryController
    {
        public IManageRepository Repository { get; private set; }

        public CategoryController(IManageRepository repository)
        {
            Repository = repository;
        }

        public void AlreadyExistKeyWordInAnoterCategory(string pKeyWord)
        {
            List<Category> categories = Repository.GetCategories();
            foreach (Category category in categories)
            {
                if (category.ExistThisKey(pKeyWord))
                    throw new ExcepcionInvalidRepeatedKeyWordsInAnotherCategory();
            }
        }

        public Category FindCategoryByName(string categoryName)
        {
            return Repository.FindCategoryByName(categoryName);
        }

        private void AddCategoryInAllBudgets(Category category)
        {
            foreach (Budget budget in Repository.GetBudgets())
            {
                budget.AddBudgetCategory(category);
            }
        }

        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            Category category = Repository.SetCategory(vName, vKeyWords);
            AddCategoryInAllBudgets(category);
            return category;
        } 

        private List<Expense> GetExpenses()
        {
            return Repository.GetExpenses();
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
            List<Budget> budgets = Repository.GetBudgets();
            foreach (Budget budget in budgets)
            {
                budget.EditBudgetCategory(oldCategory, newCategory);
            }
        }

        public void EditCategory(Category oldCategory, string newName, List<string> newKeywords)
        {
            Repository.DeleteCategory(oldCategory);
            Category newCategory = SetCategory(newName, newKeywords);
            EditCategoryInAllExpenses(oldCategory, newCategory);
            EditCategoryInAllBudgets(oldCategory, newCategory);
        }

        public List<Category> GetCategories()
        {
            return Repository.GetCategories();
        }      

    }

}