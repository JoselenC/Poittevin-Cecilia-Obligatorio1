using BusinessLogic;
using DataAcess.Configurations;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace DataAccess
{
    class ContextDB: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Budget> Budget { get; set; }

        public ContextDB() : base("name=DA1Obli")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CurrencyTypeConfiguration());
            modelBuilder.Configurations.Add(new ExpenseTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new BudgetTypeConfiguration());
            modelBuilder.Configurations.Add(new BudgetCategoryTypeConfiguration());
        }
    }
}
