using BusinessLogic;
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
        }
    }
}
