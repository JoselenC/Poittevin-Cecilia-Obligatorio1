using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class FactoryExportReport
    {
        public IExportExpenseReport GetExpenseReportInstance(string type)
        {
            if (type=="txt")
                return new ExpenseReportTXT();
            else
               return new ExpenseReportCSV();
        }
    }
}
