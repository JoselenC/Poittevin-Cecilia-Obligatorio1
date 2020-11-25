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
    public class ExpenseReportTXTTEst
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
                sw.WriteLine(expense.CreationDate.ToString("dd/MM/yyyy"));
                sw.WriteLine(expense.Description);
                sw.WriteLine(expense.Category.Name);
                sw.WriteLine(expense.Currency.Symbol);
                sw.WriteLine(expense.Amount.ToString());
                sw.WriteLine("####");
            }
            ExpenseReportTXT expensereport = new ExpenseReportTXT();
            expensereport.ExportReport(expenses, "archivo");

        }
    }
}
