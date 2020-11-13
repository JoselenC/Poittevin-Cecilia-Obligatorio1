
using BusinessLogic;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Configurations
{ 
    class CurrencyTypeConfiguration : EntityTypeConfiguration<Currency>

    {
       
        public CurrencyTypeConfiguration() {
           HasKey(x => x.Name); 
        }


    }
}
