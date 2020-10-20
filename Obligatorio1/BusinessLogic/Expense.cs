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
        private double amount;

        private DateTime creationDate;

        private string description;

        public double Amount{get=>amount; set=>SetAmount(value); }

        public DateTime CreationDate { get=>creationDate; set=>SetdDate(value); }

        public string Description { get=>description; set=>SetDescription(value); }

        public Category Category { get; set;}

        private void SetdDate(DateTime vCreationdate)
        {
            if (vCreationdate.Year > 2030 || vCreationdate.Year < 2018)
                throw new ExcepcionInvalidYearExpense();
            creationDate = vCreationdate;
        }

        private void SetAmount(double vAmount)
        {
            if (vAmount <= 0)
                throw new ExcepcionNegativeAmountExpense();
            if (vAmount!= Math.Round(vAmount, 2))
                throw new ExcepcionInvalidAmountExpense();
            amount = vAmount;
        }

        private void SetDescription(string vDescription)
        {
            if (vDescription.Length < 3 || vDescription.Length > 20)
                throw new ExcepcionInvalidDescriptionLengthExpense();
            description = vDescription;
        }            

        public override bool Equals(object obj)
        {
            if (obj is Expense expense)
            {
                bool equalsAmount = amount == expense.amount;
                bool equalsCreationDate = creationDate == expense.creationDate;
                bool equalsDescription = description == expense.description;
                return equalsAmount && equalsCreationDate && equalsDescription;
            }
            return false;
        }

        public override string ToString()
        {
            return description;
        }
    }
}