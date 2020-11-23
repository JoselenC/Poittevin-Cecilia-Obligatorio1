using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class BudgetReportLine
    {

        public double TotalAmount { get; }

        public Months Month { get; }

        public int Year { get; }

        public List<BudgetCategory> BudgetCategories { get; }

    }
}
