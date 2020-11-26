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

        public override bool Equals(object obj)
        {

            if (obj is BudgetReportLine line)
            {
                bool total = TotalAmount == line.TotalAmount;
                bool planed = PlanedAmount == line.PlanedAmount;
                bool real = RealAmount == line.RealAmount;
                bool diff = DiffAmount == line.DiffAmount;
                bool month = Month == line.Month;
                bool year = Year == line.Year;
                return 
                   total &&
                   planed &&
                   real &&
                   diff &&
                   month &&
                   year &&
                   EqualityComparer<Category>.Default.Equals(Category, line.Category);
            };
            return false;
            
        }
    }
}
