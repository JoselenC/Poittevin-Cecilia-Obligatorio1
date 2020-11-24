using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    
    public class GenerateExpenseReport
    {
        public double TotalAmount { get ; set; }

        public List<ExpenseReportLine> ExpenseReportLine { get; set; }

     
        
    }
}
