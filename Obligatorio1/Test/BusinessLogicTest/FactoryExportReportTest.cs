using System;
using BusinessLogic;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class FactoryExportReportTest
    {
        [TestMethod]
        public void GetExpenseReportCaseTXT()
        {
            FactoryExportReport export = new FactoryExportReport();
            IExportExpenseReport IExport = export.GetExpenseReportInstance("txt");
            IExportExpenseReport IExportExpected = new ExpenseReportTXT();
            Assert.AreEqual(IExport, IExportExpected);

        }

        [TestMethod]
        public void GetExpenseReportCaseCSV()
        {
            FactoryExportReport export = new FactoryExportReport();
            IExportExpenseReport IExport = export.GetExpenseReportInstance("csv");
            IExportExpenseReport IExportExpected = new ExpenseReportCSV();
            Assert.AreEqual(IExport, IExportExpected);

        }
    }
}
