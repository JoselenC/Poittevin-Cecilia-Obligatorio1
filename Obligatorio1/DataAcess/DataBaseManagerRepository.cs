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

        public void DeleteCurrency(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrencyToEdit(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency)
        {
            throw new NotImplementedException();
        }

        public Budget FindBudget(string month, int year)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryByDescription(string vDescription)
        {
            //using (ContextDB context = new ContextDB())
            //{
            //    foreach (CategoryDto categoryDto in context.Categories)
            //    {
            //        if (categoryDto.ExistKeyWordInDscription(vDescription))
            //            return mapCategoryDtoToDomain(categoryDto);
            //    }
            //}
            //throw new NoAsignCategoryByDescriptionExpense();
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

        public Currency FindCurrency(Currency Currency)
        {
            throw new NotImplementedException();
        }

        public Currency FindCurrencyByName(string CurrencyName)
        {
            throw new NotImplementedException();
        }

 

        public List<Expense> GetExpenseByMonth(Months month)
        {
            using (ContextDB context = new ContextDB())
            {
                List<Expense> expenses = new List<Expense>();
                foreach (ExpenseDTO expenseDTO in context.Expenses)
                {
                    if(expenseDTO.IsExpenseSameMonth(month))
                    expenses.Add(mapExpenseDtoToDomain(expenseDTO));
                }
                return expenses;
            }
        }

        public List<Expense> GetExpenses()
        {
            using (ContextDB context = new ContextDB())
            {
                List<Expense> expenses= new List<Expense>();
                foreach (ExpenseDTO expenseDTO in context.Expenses)
                {
                    expenses.Add(mapExpenseDtoToDomain(expenseDTO));
                }
                return expenses;
            }
        }

        private Currency mapCurrencyDtoToDomain(CurrencyDto currency)
        {
            return new Currency()
            {
                Name=currency.Name,
                Quotation=currency.Quotation,
                Symbol=currency.Symbol
            };

        }

        private CurrencyDto mapCurrencyDomainToDto(Currency currency)
        {
            return new CurrencyDto()
            {
                Name= currency.Name,
                Quotation = currency.Quotation,
                Symbol = currency.Symbol,
            };
        }

        public List<Currency> GetCurrencies()
        {
            using (ContextDB context = new ContextDB())
            {
                List<Currency> currencies = new List<Currency>();
                foreach (CurrencyDto currencyDto in context.Currencies)
                {
                    currencies.Add(mapCurrencyDtoToDomain(currencyDto));
                }
                return currencies;
            }
        }

        public void SetBudget(Budget vBudget)
        {
            throw new NotImplementedException();
        }

        private Expense mapExpenseDtoToDomain(ExpenseDTO expense)
        {
            return new Expense()
            {
                Description = expense.Description,
                Amount = expense.Amount,
                CreationDate = expense.CreationDate
            };
        }

        private ExpenseDTO mapExpenseDomainToDto(Expense expense)
        {
            return new ExpenseDTO()
            {
                Amount = expense.Amount,
                Description = expense.Description,
                CreationDate = expense.CreationDate,                
            };
        }

        public void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency)
        {
            using (ContextDB context = new ContextDB())
            {

                Expense expense = new Expense()
                {
                    Description = description, Amount = amount, CreationDate = creationDate
                };
                context.Expenses.Add(mapExpenseDomainToDto(expense));
                context.SaveChanges();
            }
        }
        private bool AlreadyExistTheCurrencyName(string CurrencyName)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencyName.ToLower() == Currency.Name.ToLower())
                    exist = true;
            }
            return exist;
        }

        private bool AlreadyExistTheCurrencySymbol(string CurrencySymbol)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencySymbol.ToLower() == Currency.Symbol.ToLower())
                    exist = true;
            }
            return exist;
        }

        public void SetCurrency(Currency vCurrency)
        {

            if (AlreadyExistTheCurrencyName(vCurrency.Name))
                throw new ExceptionAlreadyExistTheCurrencyName();
            if (AlreadyExistTheCurrencySymbol(vCurrency.Symbol))
                throw new ExceptionAlreadyExistTheCurrencySymbol();
            using (ContextDB context = new ContextDB())
            {
                Currency currency = new Currency()
                {
                    Name=vCurrency.Name,
                    Symbol=vCurrency.Symbol,
                    Quotation=vCurrency.Quotation
                };
                context.Currencies.Add(mapCurrencyDomainToDto(currency));
                context.SaveChanges();
            }
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
