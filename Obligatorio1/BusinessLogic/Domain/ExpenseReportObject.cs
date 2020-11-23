using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    
    public class ExpenseReportObject
    {
        ExpenseController expenseController;
        public double TotalAmount { get ; set; }

        public List<ExpenseReportLine> ExpenseReportLine { get; set; }

        public ExpenseReportObject(string month, IManageRepository vRepository)
        {
            expenseController = new ExpenseController(vRepository);
            ExpenseReportLine = expenseController.GetExpenseReport(month);
            foreach (ExpenseReportLine expenseLine in ExpenseReportLine)
            {
                TotalAmount += expenseLine.AmountInPesos;
            }
            
        }
        
    }
}
