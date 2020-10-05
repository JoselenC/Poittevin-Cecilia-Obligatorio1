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
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        private bool ValidDate(DateTime date)
        {
            if (date.Year > 2030 || date.Year < 2018) { return false; }
            return true;
        }

        private bool ValidAmount(double amountPassed)
        {
            if (amountPassed <= 0) { return false; }
            if (amountPassed != Math.Round(amountPassed, 2)) { return false; }
            else { return true; }
        }

        private bool ValidDescription(string description)
        {
            if (description.Length < 3 || description.Length > 20) { return false; }
            else { return true; }
        }


        public Expense(double amountPassed, DateTime creationDatePassed, string descriptionPassed, Repository repository)
        {
            if (!ValidAmount(amountPassed) || !ValidDescription(descriptionPassed))
            {
                throw new InvalidOperationException();
            }
            else if (!ValidDate(creationDatePassed))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.Amount = amountPassed;
                this.CreationDate = creationDatePassed;
                this.Description = descriptionPassed;
                this.Category = repository.FindCategoryByDescription(this.Description);

            }
        }
        public Expense(double amountPassed, DateTime creationDatePassed, string descriptionPassed)
        {
            if (!ValidAmount(amountPassed) || !ValidDescription(descriptionPassed))
            {
                throw new InvalidOperationException();
            }
            else if (!ValidDate(creationDatePassed))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.Amount = amountPassed;
                this.CreationDate = creationDatePassed;
                this.Description = descriptionPassed;
                this.Category = null;
            }
        }

    }
}