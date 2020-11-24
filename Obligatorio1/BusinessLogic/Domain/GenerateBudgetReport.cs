using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class GenerateBudgetReport
    {
        public List<BudgetReportLine> budgetsReportLines { get; set; }

     
        public double PlaneedAmount { get; set; }

        public double RealAmount { get; set; }
        public double TotalAmount { get; set; }
        public double DiffAmount { get; set; }
    }
}
