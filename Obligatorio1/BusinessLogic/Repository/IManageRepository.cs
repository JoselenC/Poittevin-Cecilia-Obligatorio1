using System;
using System.Collections.Generic;

namespace BusinessLogic.Repository
{
    public interface IManageRepository
    {
        void DeleteCategory(Category category);
        void DeleteExpense(Expense expense);
        void DeleteCurrency(Currency Currency);
        void DeleteCurrencyToEdit(Currency Currency);
        void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency);
        Budget FindBudget(string month, int year);
        Category FindCategoryByDescription(string vDescription);
        Category FindCategoryByName(string categoryName);
        Expense FindExpense(Expense vExpense);
        Currency FindCurrency(Currency Currency);
        Currency FindCurrencyByName(string CurrencyName);
        List<Budget> GetBudgets();
        List<Category> GetCategories();
        List<Expense> GetExpenseByMonth(Months month);
        List<Expense> GetExpenses();
        List<Currency> GetCurrencies();
        void SetBudget(Budget vBudget);
        Category SetCategory(string vName, List<string> vKeyWords);
        void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency);
        void SetCurrency(Currency Currency);
    }
}