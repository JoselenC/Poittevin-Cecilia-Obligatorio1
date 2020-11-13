using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Configurations
{
    class BudgetCategoryTypeConfiguration: EntityTypeConfiguration<BudgetCategory>
    {  
        public BudgetCategoryTypeConfiguration()
        {
            HasKey(x => x.Amount);
        }
    }
}
