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

        public override bool Equals(object obj)
        {
            if (obj is GenerateBudgetReport report)
            {
                bool planed = PlaneedAmount == report.PlaneedAmount;
                bool real = RealAmount == report.RealAmount;
                bool total = TotalAmount == report.TotalAmount;
                bool diff = DiffAmount == report.DiffAmount;
                return planed && real && total && diff && 
                    budgetsReportLines.OrderBy(t => t.DiffAmount).SequenceEqual(report.budgetsReportLines.OrderBy(t => t.DiffAmount));
            };
            return false;
        }
    }
}
