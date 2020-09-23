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
        public int amount { get; set; }
        public DateTime creationDate { get; set; }

        public Expense()
        {
            this.amount = 0;
            this.creationDate = DateTime.MinValue;
        }

        public bool validDate(DateTime date)
        {
            if (date.Year > 2020) return false;
            return true;
        }

        public Expense(int amountPassed, DateTime creationDatePassed)
        {
            if (!validDate(creationDate))
            {
                //Que hago aca?
            }
            this.amount = amountPassed;
            this.creationDate = creationDatePassed;
        }
    }
}
