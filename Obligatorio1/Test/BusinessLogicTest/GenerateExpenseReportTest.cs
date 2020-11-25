using System;
using System.Collections.Generic;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GenerateExpenseReportTest
    {
        [TestMethod]
        public void  SetGetTotalAmount()
        {
            GenerateExpenseReport generate = new GenerateExpenseReport();
            generate.TotalAmount=23;
            Assert.AreEqual(generate.TotalAmount, 23);
        }

        [TestMethod]
        public void SetGetExpenseReportLine()
        {
            List<ExpenseReportLine> ExpenseReportLine = new List<ExpenseReportLine>();
            GenerateExpenseReport generate = new GenerateExpenseReport();
            generate.ExpenseReportLine = ExpenseReportLine;
            Assert.AreEqual(generate.ExpenseReportLine,ExpenseReportLine);
        }
    }

}
