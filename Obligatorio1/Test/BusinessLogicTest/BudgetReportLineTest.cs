using System;
using BusinessLogic;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetReportLineTest
    {
        [TestMethod]
        public void EqualsCaseTrue()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year=2020,
            };
            Assert.AreEqual(budgetReport, budgetReport);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffTotalAmount()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffPlanedAmount()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 20,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffRealAmount()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 12,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffDiffAmount()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 51,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffMonth()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.March,
                Year = 2020,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffYear()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2021,
            };
            BudgetReportLine budgetReport2 = new BudgetReportLine()
            {
                TotalAmount = 24,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2020,
            };
            Assert.AreNotEqual(budgetReport, budgetReport2);
        }

        [TestMethod]
        public void EqualsCaseFalseDiffObj()
        {
            BudgetReportLine budgetReport = new BudgetReportLine()
            {
                TotalAmount = 23,
                PlanedAmount = 30,
                RealAmount = 10,
                DiffAmount = 5,
                Category = null,
                Month = Months.April,
                Year = 2021,
            };
            Currency currency = new Currency();
            Assert.AreNotEqual(budgetReport, currency);
        }
    }
}
