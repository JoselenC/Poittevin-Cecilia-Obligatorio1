using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBModels
{
    class CurrencyDto
    {
        public int CurrencyDtoID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Quotation { get; set; }
    }
}
