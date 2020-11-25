using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class ExpenseReportLine
    {
        public double Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public Currency Currency { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ExpenseReportLine expense)
            {
                bool equalsAmount = Amount == expense.Amount;
                bool equalsCreationDate = CreationDate == expense.CreationDate;
                bool equalsDescription = Description == expense.Description;
                bool equalsCurrency = Currency.Equals(expense.Currency);
                return equalsAmount && equalsCreationDate && equalsDescription && equalsCurrency;
            }
            return false;
        }


    }
}
