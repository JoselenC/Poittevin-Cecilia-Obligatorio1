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

        
        public bool validDate(DateTime date)
        {
            if (date.Year > 2020 || date.Year<1900) return false;
            if (date.Month > 12 || date.Month < 1) return false;
            if (date.Day < 1) return false;
            if ((date.Month==1|| date.Month == 3 || date.Month == 5 || 
                date.Month ==7 || date.Month == 8 || date.Month == 10|| 
                  date.Month ==12) && date.Day>31 ) return false;
            if ((date.Month == 4 || date.Month == 6 || date.Month == 9 ||
                date.Month == 11) && date.Day > 30) return false;
            if (date.Month == 2 && date.Day > 28) return false;

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
