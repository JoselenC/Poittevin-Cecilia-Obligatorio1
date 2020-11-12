using BusinessLogic;
using BusinessLogic.Repository;
using DataAcess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAcces
{
    public class DataBaseManagerRepository : IManageRepository
    {
        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteExpense(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoney(Money money)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoneyToEdit(Money money)
        {
            throw new NotImplementedException();
        }

        public void EditMoneyAllExpense(Money oldMoney, Money newMoney)
        {
            throw new NotImplementedException();
        }

        public Budget FindBudget(string month, int year)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryByName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Expense FindExpense(Expense vExpense)
        {
            throw new NotImplementedException();
        }

        public Money FindMoney(Money money)
        {
            throw new NotImplementedException();
        }

        public Money FindMoneyByName(string moneyName)
        {
            throw new NotImplementedException();
        }

 

        public List<Expense> GetExpenseByMonth(Months month)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public List<Money> GetMonies()
        {
            throw new NotImplementedException();
        }

        public void SetBudget(Budget vBudget)
        {
            throw new NotImplementedException();
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Money money)
        {
            throw new NotImplementedException();
        }

        public void SetMoney(Money money)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            using (ContextDB context = new ContextDB())
            {
                List<Category> categories = new List<Category>();
                foreach (CategoryDto categoryDto in context.Categories)
                {
                    categories.Add(mapCategoryDtoToDomain(categoryDto));
                }
                return categories;
            }
        }
        public Category SetCategory(string vName, List<string> vKeyWords)
        {
            using(ContextDB context = new ContextDB())
            {

                Category category = new Category()
                {
                    Name = vName
                };
                context.Categories.Add(mapCategoryDomainToDto(category));
                context.SaveChanges();
                return category;
            }
        }
        public List<Budget> GetBudgets()
        {
            using (ContextDB context = new ContextDB())
            {
                List<Budget> budgets = new List<Budget>();
                foreach (BudgetDto budgetDto in context.Budgets)
                {
                    budgets.Add(mapBudgetDtoToDomain(budgetDto));
                }
                return budgets;
            }
        }

        private CategoryDto mapCategoryDomainToDto(Category category)
        {
            return new CategoryDto()
            {
                Name = category.Name,
            };
        }
        private Category mapCategoryDtoToDomain(CategoryDto category)
        {
            return new Category()
            {
                Name = category.Name,
            };
        }
        private Budget mapBudgetDtoToDomain(BudgetDto budget)
        {
            return new Budget((Months)budget.Month)
            {
                TotalAmount = budget.TotalAmount,
                Year = budget.Year
            };
        }
    }
}
