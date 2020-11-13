using BusinessLogic;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{
    class CategoryTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryTypeConfiguration()
        {
            HasKey(x => x.Name);
        }
    }
}
