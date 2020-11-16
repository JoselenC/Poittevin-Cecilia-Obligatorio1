using BusinessLogic;
using DataAcess.DBObjects;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{
    class CategoryTypeConfiguration : EntityTypeConfiguration<CategoryDto>
    {
        public CategoryTypeConfiguration()
        {
            HasKey(x => x.Name);
        }
    }
}
