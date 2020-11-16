using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    class CurrencyDto
    {
        [Key]
        public string Name { get; set; }

        public string Symbol { get; set ; }

        public double Quotation { get; set; }
    }
}
