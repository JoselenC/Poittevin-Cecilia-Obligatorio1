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
        }

        public ManageMemoryRepository(List<Category> vCategories)
        {
            Categories = new MemoryRepository<Category>();
            Expenses = new MemoryRepository<Expense>();
            Budgets = new MemoryRepository<Budget>();
            Currencies = new MemoryRepository<Currency>();
            Categories.Set(vCategories);
        }
    }
}