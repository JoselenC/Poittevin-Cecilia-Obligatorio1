using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ExpenseReportCSVTest
    {
        [TestMethod]
        public void ExportReport()
        {
           
            Currency currency = new Currency { Name = "euro", Quotation = 23, Symbol = "E" };
            Category category = new Category() { Name = "food" };
            double amount = 23;
            Expense expense = new Expense { Description = "Dinner", Amount = amount, CreationDate = new DateTime(2020, 01, 01), Category = category, Currency = currency };
            List<Expense> expenses = new List<Expense>() { expense };
            StreamWriter sw;
            using (sw = new StreamWriter("archivo"))
            {
                    sw.WriteLine(expense.CreationDate.ToString("dd/MM/yyyy") + "," + expense.Description + "," +
                        expense.Category.Name + "," + expense.Currency.Symbol + "," + expense.Amount.ToString());                
            }
            ExpenseReportCSV expensereport = new ExpenseReportCSV();
            expensereport.ExportReport(expenses,"archivo");

        }
    }

    
}
