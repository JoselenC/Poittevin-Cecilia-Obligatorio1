using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DataAcess.DBModels
{
    class ExpenseDTO
    {
        public int ExpenseDTOID { get; set; }

        public string Description{ get; set; }

        public double Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsExpenseSameMonth(Months month)
        {
            int expected = CreationDate.Month;
            int actual = (int)month;
            return expected == actual;
        }
    }
}
