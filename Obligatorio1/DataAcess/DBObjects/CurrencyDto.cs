using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    class CurrencyDto
    {
        public int CurrencyDtoID { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string Symbol { get; set ; }

        public double Quotation { get; set; }
    }
}
