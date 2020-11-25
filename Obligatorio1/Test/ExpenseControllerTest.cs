using System;
using DataAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Repository;
using BusinessLogic;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ExpenseControllerTest
    {

        private static List<string> keyWords1 = new List<string>();
        private static ManagerRepository repo = new ManageMemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static ExpenseController expenseController;

        private static Expense expenseDesktopGame;
        private static Expense expenseVideoGame;
        private static Expense expenseSushi;
        private static Expense expenseBurgers;


        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            expenseController = new ExpenseController(repo);
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
            categoryController.SetCategory(categoryEntertainment);
            categoryController.SetCategory(categoryFood);
            categoryController.SetCategory(categoryHouse);

            expenseDesktopGame = new Expense() 
            { 
                Description = "buy desktop game", 
                Amount = 230.15, 
                Category = categoryEntertainment, 
                CreationDate = new DateTime(2020, 8, 1) 
            };
            expenseSushi = new Expense()
            {
                Description = "sushi night",
                Amount = 220,
                Category = categoryFood,
                CreationDate = new DateTime(2020, 8, 1)
            };
            expenseBurgers = new Expense()
            {
                Description = "burgers night",
                Amount = 110.50,
                Category = categoryFood,
                CreationDate = new DateTime(2020, 1, 1)
            };
            expenseVideoGame = new Expense()
            {
                Description = "buy video game",
                Amount = 230.15,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 1, 1)
            };
            expenseController.SetExpense(expenseDesktopGame);
            expenseController.SetExpense(expenseSushi);
            expenseController.SetExpense(expenseBurgers);
            expenseController.SetExpense(expenseVideoGame);
        }

        [TestMethod]
        public void FindExpense()
        {
            Expense expectedExpense = expenseController.FindExpense(expenseSushi);
            Assert.AreEqual(expenseSushi, expectedExpense);
        }


        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpense()
        {
            Expense expense = new Expense { 
                Description = "movie theater", 
                Amount = 24, 
                Category = categoryFood, 
                CreationDate = new DateTime(2020, 01, 01) 
            };
            expenseController.FindExpense(expense);
            
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpenseEmtyRepository()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            Expense expectedExpense = controller.FindExpense(expense);
        }

        [TestMethod]
        public void FindCategoryEntertainment()
        {
            string description = "movie theater";
            Category expectedCategory = expenseController.FindCategoryByDescription(description);
            Assert.AreEqual(categoryEntertainment, expectedCategory);

        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultForEntertainment()
        {
            string description = "movie theater and CoffeMaker";
            Category expectedCategory = expenseController.FindCategoryByDescription(description);
        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultFood()
        {
            string description = "";
            expenseController.FindCategoryByDescription(description);

        }

        [TestMethod]
        public void FindCategoryValueResultForFood()
        {
            string description = "when we went to McDonalds last night";
            Category expectedCategory = expenseController.FindCategoryByDescription(description);
            Assert.AreEqual(categoryFood, expectedCategory);

        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindRemoveExpense()
        {
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "Testing Dinner", Category = categoryFood };
            
            expenseController.SetExpense(expense);
            expenseController.DeleteExpense(expense);
            
            expenseController.FindExpense(expense);
        }

        [TestMethod]
        public void MonthsOrderedInWhichAreExpenses()
        {

            List<string> months = new List<string>()
            {
            "January",
            "August",
            };
            List<string> monthsOrder = expenseController.OrderedMonthsWithExpenses();
            CollectionAssert.AreEqual(months, monthsOrder);
        }

        [TestMethod]
        public void ExpensesByMonth()
        {
            Months monthOctober = Months.October;
            Expense expense1 = new Expense { 
                Amount = 23, 
                CreationDate = new DateTime(2020, 10, 01), 
                Description = "when we go movies",
                Category = categoryEntertainment
            };
            expenseController.SetExpense(expense1);

            Assert.AreEqual(expense1, expenseController.GetExpenseByMonth(monthOctober).ToArray()[0]);
            expenseController.DeleteExpense(expense1);
        }

        [TestMethod]
        public void ExpensesByMonthEmpty()
        {
            Months month = Months.May;
            Assert.AreEqual(0, expenseController.GetExpenseByMonth(month).Count);
        }

        [TestMethod]
        public void ExpensesByMonthString()
        {
            Expense expense1 = new Expense 
            { 
                Amount = 23, 
                CreationDate = new DateTime(2020, 05, 01), 
                Description = "when we go movies", 
                Category = categoryEntertainment
            };
            expenseController.SetExpense(expense1);

            Assert.AreEqual(expense1, expenseController.GetExpenseByMonth("May").ToArray()[0]);
            expenseController.DeleteExpense(expense1);

        }

        [TestMethod]
        public void ExpensesByMonthEmptyString()
        {
            Assert.AreEqual(0, expenseController.GetExpenseByMonth("May").Count);
        }

        [TestMethod]
        public void CreateAddExpense()
        {
            Expense expence = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            expenseController.SetExpense(expence);
            Assert.AreEqual(expence, expenseController.FindExpense(expence));
        }

        [TestMethod]
        public void AmountOfExpensesInAMonthSuccessCase()
        {
            Months month = Months.August;

            double totalAmount = expenseController.AmountOfExpensesInAMonth(month);

            Assert.AreEqual(450.15, totalAmount);

        }

    }
}
