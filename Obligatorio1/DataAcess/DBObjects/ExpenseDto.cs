using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    class ExpenseDto
    {
        public int ExpenseDtoID { get; set; }
        public string Description { get; set; }

        public double Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public int CategoryDtoID { get; set; }
        public CategoryDto Category { get; set; }

        public int CurrencyDtoID { get; set; }
        public CurrencyDto Currency { get; set; }
    }
}
