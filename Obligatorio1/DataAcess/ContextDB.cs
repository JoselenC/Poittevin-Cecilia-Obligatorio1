using DataAcess.DBModels;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace DataAcces
{
    class ContextDB: DbContext
    {
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<BudgetDto> Budgets { get; set; }
        public DbSet<ExpenseDTO> Expenses { get; set; }
        public DbSet<CurrencyDto> Currencies { get; set; }

        public ContextDB() : base("name=DA1Obli")
        {
        }
    }
}
