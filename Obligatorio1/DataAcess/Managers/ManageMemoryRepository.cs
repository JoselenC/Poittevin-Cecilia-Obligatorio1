using BusinessLogic;
using DataAccess;
using System.Collections.Generic;

namespace DataAcces
{

    public class ManageMemoryRepository : ManageRepository
    {
        public ManageMemoryRepository()
        {
            Categories = new MemoryRepository<Category>();
            Expenses = new MemoryRepository<Expense>();
            Budgets = new MemoryRepository<Budget>();
            Currencies = new MemoryRepository<Currency>();
            Currency money = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Currencies.Add(money);
        }

        public ManageMemoryRepository(List<Category> vCategories)
        {
            Categories = new MemoryRepository<Category>();
            Expenses = new MemoryRepository<Expense>();
            Budgets = new MemoryRepository<Budget>();
            Currencies = new MemoryRepository<Currency>();
            Categories.Set(vCategories);
            Currency money = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            Currencies.Add(money);
        }
    }
}