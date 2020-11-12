using DataAcess.DBModels;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace DataAcces
{
    class ContextDB: DbContext
    {
        public DbSet<CategoryDto> Categories { get; set; }
        public ContextDB() : base("name=DA1Obli")
        {
        }
    }
}
