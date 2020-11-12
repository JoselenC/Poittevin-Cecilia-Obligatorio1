using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBModels
{
    class BudgetDto
    {
        public int BudgetDtoID { get; set; }
        public double TotalAmount { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }
}
