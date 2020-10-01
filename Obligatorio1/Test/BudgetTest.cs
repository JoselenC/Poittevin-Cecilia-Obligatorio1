using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void TestCreateBudgetMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, totalAmount, currentYear);
            Assert.AreEqual(currentMonth, budget);
        }

        [TestMethod]
        public void TestCreateBudgetYear()
        {
            Console.WriteLine("iniciando la prueba");
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentMonth, totalAmount, currentYear);
            Console.WriteLine("budget creado");
            Assert.AreEqual(currentMonth, budget.CurrentYear);
        }

        [TestMethod]
        public void TestCreateBudgetWithDateInThePass()
        {
            int currentDate = DateTime.Now.AddMonths(-1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount, currentYear);
            Assert.AreEqual(currentDate, budget.CurrentMonth);
        }
        
        [TestMethod]
        public void TestCreateBudgetWithDateInTheFeature()
        {
            int currentDate = DateTime.Now.AddMonths(1).Month;
            int currentYear = DateTime.Now.Year;
            double totalAmount = 4000;
            Budget budget = new Budget(currentDate, totalAmount, currentYear);
            Assert.AreEqual(currentDate, budget.CurrentMonth);
        }

        [TestMethod]
        public void TestCreateBudgetTotalAmount()
        {
            double totalAmount = 4000;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount, DateTime.Now.Year);
            Assert.AreEqual(4000, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithCeroTotalAmount()
        {
            double totalAmount = 0;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount, DateTime.Now.Year);
            Assert.AreEqual(0, budget.TotalAmount);
        }

        [TestMethod]
        public void TestCreateBudgetWithBigTotalAmount()
        {
            double totalAmount = int.MaxValue;

            Budget budget = new Budget(DateTime.Now.Month, totalAmount, DateTime.Now.Year);
            Assert.AreEqual(int.MaxValue, budget.TotalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeValueErrorAttribute))]
        public void TestCreateBudgetWithNegativeTotalAmount()
        {
            double totalAmount = -1;

            new Budget(DateTime.Now.Month, totalAmount, DateTime.Now.Year);
        }
    }
}
