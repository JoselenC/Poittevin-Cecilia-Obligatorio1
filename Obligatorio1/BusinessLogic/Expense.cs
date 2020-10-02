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

        public string description { get; set; }


        public bool validDate(DateTime date)
        {
            if (date.Year > 2030 || date.Year < 2018) { return false; }
            return true;
        }

        public bool validAmount(double amountPassed)
        {
            if (amountPassed <= 0) { return false; }
            if (amountPassed != Math.Round(amountPassed,2)) { return false; }
            else { return true; }
        }

        public bool validDescription(string description)
        {
            if (description.Length<3 || description.Length>20) { return false; }
            else { return true; }
        }


        public Expense(double amountPassed, DateTime creationDatePassed, string descriptionPassed)
        {
            if (!validAmount(amountPassed) || !validDescription(descriptionPassed))
            {
                throw new InvalidOperationException();
            }
            else if (!validDate(creationDatePassed))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.amount = amountPassed;
                this.creationDate = creationDatePassed;
                this.description = descriptionPassed;
            }
        }
    }
}
