using System;
using System.Collections.Generic;

namespace BusinessLogic.Repository
{
    public interface IManageRepository
    {
        void DeleteCategory(Category category);
        void DeleteExpense(Expense expense);
        void DeleteMoney(Money money);
        void DeleteMoneyToEdit(Money money);
        void EditMoneyAllExpense(Money oldMoney, Money newMoney);
        Budget FindBudget(string month, int year);
        Category FindCategoryByDescription(string vDescription);
        Category FindCategoryByName(string categoryName);
        Expense FindExpense(Expense vExpense);
        Money FindMoney(Money money);
        Money FindMoneyByName(string moneyName);
        List<Budget> GetBudgets();
        List<Category> GetCategories();
        List<Expense> GetExpenseByMonth(Months month);
        List<Expense> GetExpenses();
        List<Money> GetMonies();
        void SetBudget(Budget vBudget);
        Category SetCategory(string vName, List<string> vKeyWords);
        void SetExpense(double amount, DateTime creationDate, string description, Category category, Money money);
        void SetMoney(Money money);
    }
}