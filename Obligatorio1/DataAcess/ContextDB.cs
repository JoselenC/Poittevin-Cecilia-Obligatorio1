using BusinessLogic;
using DataAcess.Configurations;
using DataAcess.DBObjects;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace DataAccess
{
    class ContextDB: DbContext
    {
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ExpenseDto> Expenses { get; set; }
        public DbSet<CurrencyDto> Currencies { get; set; }

        public DbSet<BudgetDto> Budget { get; set; }

        public ContextDB() : base("name=DA1Obli")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Configurations.Add(new CurrencyTypeConfiguration());
            modelBuilder.Configurations.Add(new ExpenseTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new BudgetTypeConfiguration());
            modelBuilder.Configurations.Add(new BudgetCategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new KeyWordTypeConfiguration());
        }
    }
}
