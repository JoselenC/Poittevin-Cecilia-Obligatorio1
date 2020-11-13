using System;
using System.Collections.Generic;

namespace BusinessLogic.Repository
{
    public interface IManageRepository
    {
        void DeleteCategory(Category category);
        void DeleteCurrency(Currency Currency);
        void DeleteCurrencyToEdit(Currency Currency);
        void DeleteExpense(Expense expense);
        void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency);
        Budget FindBudget(string month, int year);
        Category FindCategoryByDescription(string vDescription);
        Category FindCategoryByName(string categoryName);
        Currency FindCurrency(Currency Currency);
        Currency FindCurrencyByName(string CurrencyName);
        Expense FindExpense(Expense vExpense);
        List<Budget> GetBudgets();
        List<Category> GetCategories();
        List<Currency> GetCurrencies();
        List<Expense> GetExpenseByMonth(Months month);
        List<Expense> GetExpenses();
        void SetBudget(Budget vBudget);
        Category SetCategory(string vName, List<string> vKeyWords);
        void SetCurrency(Currency Currency);
        void SetExpense(double amount, DateTime creationDate, string description, Category category, Currency Currency);
    }
}