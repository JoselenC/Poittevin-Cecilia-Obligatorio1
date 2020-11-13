using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Configurations
{
    class ExpenseTypeConfiguration : EntityTypeConfiguration<Expense>
    {
        public ExpenseTypeConfiguration()
        {
            HasKey(x => x.Description);
        }
    }

}
