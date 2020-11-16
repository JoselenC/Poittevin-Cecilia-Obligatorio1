using BusinessLogic;
using DataAcess.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Configurations
{
    class KeyWordTypeConfiguration: EntityTypeConfiguration<KeyWordsDto>
    {  
        public KeyWordTypeConfiguration()
        {
            HasKey(x => x.Value);
        }
    }
}
