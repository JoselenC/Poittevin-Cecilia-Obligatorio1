using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ExpenseReportTXT: IExportExpenseReport
    {
        public void ExportReport(List<Expense> expenses, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Expense vExpense in expenses)
                {
                    sw.WriteLine(vExpense.CreationDate.ToString("dd/MM/yyyy"));
                    sw.WriteLine(vExpense.Description);
                    sw.WriteLine(vExpense.Category.Name);
                    sw.WriteLine(vExpense.Money.Symbol);
                    sw.WriteLine(vExpense.Amount.ToString());
                    sw.WriteLine("####");
                }
            }
        }
    }
}
