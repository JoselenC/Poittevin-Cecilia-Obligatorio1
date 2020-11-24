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

    }
}
