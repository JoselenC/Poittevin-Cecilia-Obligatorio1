using BusinessLogic;
using DataAcess.DBObjects;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{

    class BudgetTypeConfiguration: EntityTypeConfiguration<BudgetDto>
    {  
        public BudgetTypeConfiguration()
        {
        }
    }
}
