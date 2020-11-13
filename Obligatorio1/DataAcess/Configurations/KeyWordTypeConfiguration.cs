using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Configurations
{
    class KeyWordTypeConfiguration: EntityTypeConfiguration<KeyWord>
    {  
        public KeyWordTypeConfiguration()
        {
            HasKey(x => x.Value);
        }
    }
}
