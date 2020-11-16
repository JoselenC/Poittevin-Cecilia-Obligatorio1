
using BusinessLogic;
using DataAcess.DBObjects;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{ 
    class CurrencyTypeConfiguration : EntityTypeConfiguration<CurrencyDto>

    {
       
        public CurrencyTypeConfiguration() {
           HasKey(x => x.Name); 
        }

    }
}
