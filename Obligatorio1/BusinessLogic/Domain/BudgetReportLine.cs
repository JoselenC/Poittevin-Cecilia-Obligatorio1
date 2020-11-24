using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class BudgetReportLine
    {

        public double TotalAmount { get; set; }

        public double PlanedAmount { get; set; }

        public double RealAmount { get; set; }

        public double DiffAmount { get; set; }

        public Months Month { get; set; }

        public int Year { get; set; }

        public Category Category { get; set; }

    }
}
