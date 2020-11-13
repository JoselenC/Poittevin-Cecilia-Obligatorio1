using BusinessLogic;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{

    class BudgetTypeConfiguration: EntityTypeConfiguration<Budget>
    {  
        public BudgetTypeConfiguration()
        {
            HasKey(x => x.Year);
        }
    }
}
