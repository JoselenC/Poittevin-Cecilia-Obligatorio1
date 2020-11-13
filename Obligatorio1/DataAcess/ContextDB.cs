using DataAcess.DBModels;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
using BusinessLogic;

namespace DataAcces
{
    class ContextDB: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<BudgetDto> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public ContextDB() : base("name=DA1Obli")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CurrencyTypeConfiguration());
            modelBuilder.Configurations.Add(new ExpenseTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
        }
    }
}
