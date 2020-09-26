using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Expense
    {
        public double amount { get; set; }
        public DateTime creationDate { get; set; }

        
        public bool validDate(DateTime date)
        {
            if (date.Year > 2020 || date.Year < 1900) { return false; }
            return true;
        }

        public bool validAmount(double amountPassed)
        {
            if (amountPassed <= 0) { return false; }
            else { return true; }
        }

        public Expense(int amountPassed, DateTime creationDatePassed)
        public Expense(double amountPassed, DateTime creationDatePassed)
        {
            if (!validAmount(amountPassed))
            {
                throw new InvalidOperationException();
            }
            else if (!validDate(creationDatePassed)){
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.amount = amountPassed;
                this.creationDate = creationDatePassed;
            }
        }
    }
}
