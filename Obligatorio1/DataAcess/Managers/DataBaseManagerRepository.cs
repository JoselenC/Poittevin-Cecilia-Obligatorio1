using BusinessLogic;
using DataAccess;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace DataAcces
{
    public class DataBaseManagerRepository : ManageRepository
    {
        public DataBaseManagerRepository()
        {
            Categories = new DataBaseRepository<Category>();
            Expenses = new DataBaseRepository<Expense>();
            Budgets = new DataBaseRepository<Budget>();
            Currencies = new DataBaseRepository<Currency>();
            try
            {

                Currency money = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
                Currencies.Add(money);
            }
            catch (DbUpdateException){}
        }

        public DataBaseManagerRepository(List<Category> vCategories)
        {
            Categories = new DataBaseRepository<Category>();
            Expenses = new DataBaseRepository<Expense>();
            Budgets = new DataBaseRepository<Budget>();
            Currencies = new DataBaseRepository<Currency>();
            Categories.Set(vCategories);
            Currency money = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Currencies.Add(money);
        }
       

        //public List<Category> GetCategories()
        //{
        //    using (ContextDB context = new ContextDB())
        //    {
        //        List<Category> categories = new List<Category>();
        //        foreach (CategoryDto categoryDto in context.Categories)
        //        {
        //            categories.Add(mapCategoryDtoToDomain(categoryDto));
        //        }
        //        return categories;
        //    }
        //}
        //public Category SetCategory(string vName, List<string> vKeyWords)
        //{
        //    using(ContextDB context = new ContextDB())
        //    {

        //        Category category = new Category()
        //        {
        //            Name = vName
        //        };
        //        context.Categories.Add(mapCategoryDomainToDto(category));
        //        context.SaveChanges();
        //        return category;
        //    }
        //}
        //public List<Budget> GetBudgets()
        //{
        //    using (ContextDB context = new ContextDB())
        //    {
        //        List<Budget> budgets = new List<Budget>();
        //        foreach (BudgetDto budgetDto in context.Budgets)
        //        {
        //            budgets.Add(mapBudgetDtoToDomain(budgetDto));
        //        }
        //        return budgets;
        //    }
        //}

        //private CategoryDto mapCategoryDomainToDto(Category category)
        //{
        //    return new CategoryDto()
        //    {
        //        Name = category.Name,
        //    };
        //}
        //private Category mapCategoryDtoToDomain(CategoryDto category)
        //{
        //    return new Category()
        //    {
        //        Name = category.Name,
        //    };
        //}
        //private Budget mapBudgetDtoToDomain(BudgetDto budget)
        //{
        //    return new Budget((Months)budget.Month)
        //    {
        //        TotalAmount = budget.TotalAmount,
        //        Year = budget.Year
        //    };
        //}
    }
}
