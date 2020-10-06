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

        private void ValidDate(DateTime date)
        {
            if (date.Year > 2030 || date.Year < 2018)
                throw new ExcepcionInvalidYearExpense();
        }

        private void ValidAmount(double amountPassed)
        {
            if (amountPassed <= 0)
                throw new ExcepcionNegativeAmountExpense();

            if (amountPassed != Math.Round(amountPassed, 2))
                throw new ExcepcionInvalidAmountExpense();
        }

        private void ValidDescription(string description)
        {
            if (description.Length < 3 || description.Length > 20)
                throw new ExcepcionInvalidDescriptionLengthExpense();            
        }
               
        public Expense(double amountPassed, DateTime creationDatePassed, string descriptionPassed)
        {
            ValidAmount(amountPassed);
            ValidDescription(descriptionPassed);          
            ValidDate(creationDatePassed);            
            this.Amount = amountPassed;
            this.CreationDate = creationDatePassed;
            this.Description = descriptionPassed;
            this.Category = null;

            
        }

    }
}