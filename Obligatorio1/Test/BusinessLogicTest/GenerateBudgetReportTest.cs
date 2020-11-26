using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GenerateBudgetReportTest
    {
        [TestMethod]
        public void SetGetDiffAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport();
            generate.DiffAmount = 23;
            Assert.AreEqual(generate.DiffAmount, 23);
        }

        [TestMethod]
        public void SetGetPlaneedAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport();
            generate.PlaneedAmount = 23;
            Assert.AreEqual(generate.PlaneedAmount, 23);
        }

        [TestMethod]
        public void SetGetRealAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport();
            generate.RealAmount = 23;
            Assert.AreEqual(generate.RealAmount, 23);
        }

        [TestMethod]
        public void SetGetTotalAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport();
            generate.TotalAmount = 23;
            Assert.AreEqual(generate.TotalAmount, 23);
        }

        [TestMethod]
        public void SetGetBudgetsReportLines()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport();
            generate.budgetsReportLines = new List<BudgetReportLine>();
            List<BudgetReportLine> budgetReport = new List<BudgetReportLine>();
            CollectionAssert.AreEqual(generate.budgetsReportLines, budgetReport);
        }

        [TestMethod]
        public void EqualsBudgetsReportLines()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Assert.AreEqual(generate, generate);
        }

        [TestMethod]
        public void EqualsBudgetsReportLinesCaseFalsePlaneedAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            GenerateBudgetReport generate2 = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 4,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Assert.AreNotEqual(generate, generate2);
        }

        [TestMethod]
        public void EqualsBudgetsReportLinesCaseFalseRealAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 28,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            GenerateBudgetReport generate2 = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 4,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Assert.AreNotEqual(generate, generate2);
        }

        [TestMethod]
        public void EqualsBudgetsReportLinestotalAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 23,
                TotalAmount = 2,
                DiffAmount = 23,
            };
            GenerateBudgetReport generate2 = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 4,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Assert.AreNotEqual(generate, generate2);
        }

        [TestMethod]
        public void EqualsBudgetsReportLinesCaseFalseDiffAmount()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 2,
            };
            GenerateBudgetReport generate2 = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 4,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Assert.AreNotEqual(generate, generate2);
        }

        [TestMethod]
        public void EqualsBudgetsReportLinesCaseFalse()
        {
            GenerateBudgetReport generate = new GenerateBudgetReport()
            {
                budgetsReportLines = new List<BudgetReportLine>(),
                PlaneedAmount = 23,
                RealAmount = 23,
                TotalAmount = 23,
                DiffAmount = 23,
            };
            Currency currency = new Currency();
            Assert.AreNotEqual(generate, currency);
        }
    }
}
