using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class BudgetReportObject
    {
        public List<BudgetReportLine> budgetsReportLines { get; set; }

        public double PlaneedAmount { get; set; }

        public double RealAmount { get; set; }

        public BudgetReportObject(string )
        {
            budgetController.GetTotalSpentByMonthAndCategory(cboxMonth.Text, category);
        }
    }
}
