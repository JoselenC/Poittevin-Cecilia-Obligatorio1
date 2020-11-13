
using BusinessLogic;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.DBModels
{ 
    class CurrencyTypeConfiguration : EntityTypeConfiguration<Currency>

    {
       
        public CurrencyTypeConfiguration() {
           HasKey(x => x.Name); 
        }


    }
}
