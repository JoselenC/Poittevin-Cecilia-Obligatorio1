using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Expense
    {
        public int amount { get; set; }
        public DateTime creationDate { get; set; }

        public Expense()
        {
            this.amount = 0;
            this.creationDate = DateTime.MinValue;
        }

        public Expense(int amountPassed, DateTime creationDatePassed)
        {
            this.amount = amountPassed;
            this.creationDate = creationDatePassed;
        }
    }
}
