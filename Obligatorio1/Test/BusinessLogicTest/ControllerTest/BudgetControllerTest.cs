using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Repository;
using BusinessLogic;
using DataAcces;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Domain;

namespace Test
{
    [TestClass]
    public class BudgetControllerTest
    {
        private static List<string> keyWords1 = new List<string>();
        private static ManagerRepository repo = new ManageMemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static BudgetController budgetController;
        private static Budget JanuaryBudget;


        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {

            budgetController = new BudgetController(repo);
            ExpenseController expenseController = new ExpenseController(repo);
            CategoryController categoryController = new CategoryController(repo);
            keyWords1 = new List<string>
            {
                "movie theater",
                "theater",
                "casino"
            };
            categoryEntertainment = new Category()
            {
                Name = "entertainment",
                KeyWords = keyWords1
            };
            List<string> keyWords2 = new List<string>
            {
                "restaurant",
                "McDonalds",
                "Dinner"
            };
            categoryFood = new Category()
            {
                Name = "food",
                KeyWords = keyWords2
            };
            List<string> keyWords3 = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            categoryHouse = new Category()
            {
                Name = "House",
                KeyWords = keyWords3
            };
            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
                categoryHouse
            };

            JanuaryBudget = new Budget(Months.January, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            Currency currency = new Currency() { Name = "dolar", Symbol = "USD", Quotation = 1 };

            Currency currency2 = new Currency() { Name = "dolar", Quotation = 43, Symbol = "USD" };

            budgetController.SetBudget(JanuaryBudget);
            expenseController.SetExpense(220, new DateTime(2020, 1, 1), "sushi night", categoryFood, currency);
            expenseController.SetExpense(110.50, new DateTime(2020, 1, 1), "sushi night", categoryFood,currency2);
            expenseController.SetExpense(230.15, new DateTime(2020, 1, 1), "buy video game", categoryEntertainment,currency);
        }
        
        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryValidCase()
        {
            double expectedTotalSpentJanuary = 4971.5;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("January", categoryFood,2020);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpenses()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("March", categoryFood,2020);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpensesInCategory()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("January", categoryHouse,2020);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void BudgetGetOrCreateFindCase()
        {
            string expectedString = "month: January year: 2020 total: 0";
            string month = "January";
            int year = 2020;
            Budget budget = budgetController.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedString, budget.ToString());
        }

        [TestMethod]
        public void BudgetGetOrCreateCreateCase()
        {
            string month = "January";
            int year = 2020;
            Budget expectedBudget = new Budget(Months.December)
            {
                Year = 2020,
                TotalAmount = 0
            };
            ManagerRepository repository = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(repository);
            Budget budget = budgetController.BudgetGetOrCreate(month, year);
            Assert.AreEqual(JanuaryBudget, budget);
        }

        [TestMethod]
        public void BudgetGetOrCreateAddAndFind()
        {
            ManagerRepository emptyRepository = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(emptyRepository);
            Months month = Months.December;

            int year = 2020;
            Budget budget = new Budget(month) { 
                Year = year, 
                TotalAmount = 0 
            };
            controller.SetBudget(budget);
            Budget actualBudget = controller.BudgetGetOrCreate(Months.December.ToString(), year);
            Assert.AreEqual(budget, actualBudget);
        }

      

        [TestMethod]
        [ExpectedException(typeof(ExceptionBudgetWithEmptyCategory), "")]
        public void BudgetGetOrCreateNodFind()
        {         
            
            Months month = Months.December;
            int year = 2020;
            ManagerRepository repo = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(repo);
            Budget actualBudget =controller.BudgetGetOrCreate("December", year);
        }

        [TestMethod]
        public void BudgetGetOrCreateNoFind()
        {

            Months month = Months.December;
            int year = 2020;
            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
                categoryHouse
            };

            Budget budget = new Budget(month,categories) { Year = 2020,TotalAmount=0};
            ManagerRepository repository = new ManageMemoryRepository();
            repository.Categories.Set(categories);
            BudgetController controller = new BudgetController(repository);
            Budget actualBudget = controller.BudgetGetOrCreate("December", year);
            Assert.AreEqual(actualBudget, budget);
        }


        [TestMethod]
        public void FindBudgetFoundCase()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(repository);
            JanuaryBudget = new Budget(Months.January)
            {
                Year = 2020,
                TotalAmount = 0
            };
            controller.SetBudget(JanuaryBudget);
            
            Budget actualBudget = controller.FindBudget("January", 2020);
            Assert.AreEqual(JanuaryBudget, actualBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindBudget), "")]
        public void FindBudgetNotFoundCase()
        {
            budgetController.FindBudget("February", 2020);
        }

        [TestMethod]
        public void GetAllMonthsString()
        {
            string[] expectedMonthStrings = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            string[] allMonths = budgetController.GetAllMonthsString();
            CollectionAssert.AreEqual(allMonths, expectedMonthStrings);
        }


        [TestMethod]
        public void AddValidBudgetToRepository()
        {
            Budget validBudget = new Budget((Months)DateTime.Now.Month)
            {
                TotalAmount = 4000,
                Year = DateTime.Now.Year
            };
            ManagerRepository EmptyRepository = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(EmptyRepository);
            controller.SetBudget(validBudget);
            Budget currentBudget = controller.GetBudgets().First();
            Assert.AreEqual(validBudget, currentBudget);
        }

        [TestMethod]
        public void MonthsOrderedInWhichAreBudget()
        {
            ManagerRepository repo = new ManageMemoryRepository();
            BudgetController controller = new BudgetController(repo);

            List<string> months = new List<string>()
            {
            "January",
            "May",
            };
            Budget budget1 = new Budget(Months.January) { TotalAmount = 23, Year = 2020 };
            Budget budget2 = new Budget(Months.May) { TotalAmount = 23, Year = 2020 };
            controller.SetBudget(budget1);
            controller.SetBudget(budget2);
            List<string> monthsOrder = controller.OrderedMonthsWithBudget();
            CollectionAssert.AreEqual(months, monthsOrder);
        }

        [TestMethod]
        public void GetBudgetReportSuccessCase()
        {
            GenerateBudgetReport budgetReport = new GenerateBudgetReport
            {
                TotalAmount = 0,
                RealAmount = 5201.65,
                PlaneedAmount = 0,
                DiffAmount = -5201.65,
            };
            List<BudgetReportLine> budgetReportLines = new List<BudgetReportLine>()
            {
                new BudgetReportLine()
                {
                    Category = categoryEntertainment,
                    DiffAmount = -230.15,
                    Month = 0,
                    PlanedAmount = 0,
                    RealAmount = 230.15,
                    TotalAmount = 0,
                    Year = 0,
                },
                new BudgetReportLine()
                {
                    Category = categoryFood,
                    DiffAmount = -4971.5,
                    Month = 0,
                    PlanedAmount = 0,
                    RealAmount = 4971.5,
                    TotalAmount = 0,
                    Year = 0,
                },
                new BudgetReportLine()
                {
                    Category = categoryHouse,
                    DiffAmount = 0,
                    Month = 0,
                    PlanedAmount = 0,
                    RealAmount = 0,
                    TotalAmount = 0,
                    Year = 0,
                },

            };
            budgetReport.budgetsReportLines = budgetReportLines;
            GenerateBudgetReport expectedBudgetReport = budgetController.GetBudgetReport("January", 2020);
            Assert.AreEqual(budgetReport, expectedBudgetReport);
        }


    }
}
