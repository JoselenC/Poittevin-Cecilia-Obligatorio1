using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.DBModels
{
    class CategoryTypeConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryTypeConfiguration()
        {
            HasKey(x => x.Name);
        }
    }
}
