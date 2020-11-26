using System;
using DataAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Repository;
using BusinessLogic;
using System.Collections.Generic;
using BusinessLogic.Domain;

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
        private static Currency CurrencyPesos;


        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            expenseController = new ExpenseController(repo);
            CategoryController categoryController = new CategoryController(repo);
            CurrencyPesos = new Currency { Name = "pesos", Quotation = 1, Symbol="$U" };
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
                CreationDate = new DateTime(2020, 8, 1) ,
                Currency= CurrencyPesos
            };
            expenseSushi = new Expense()
            {
                Description = "sushi night",
                Amount = 220,
                Category = categoryFood,
                CreationDate = new DateTime(2020, 8, 1),
                Currency = CurrencyPesos
            };
            expenseBurgers = new Expense()
            {
                Description = "burgers night",
                Amount = 110.50,
                Category = categoryFood,
                CreationDate = new DateTime(2020, 1, 1),
                Currency = CurrencyPesos
            };
            expenseVideoGame = new Expense()
            {
                Description = "buy video game",
                Amount = 230.15,
                Category = categoryEntertainment,
                CreationDate = new DateTime(2020, 1, 1),
                Currency = CurrencyPesos
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
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 05, 22), Description = "Testing Dinner", Category = categoryFood };
            
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

        [TestMethod]
        public void ExportExpenseReport()
        {
            string description = "movie theater";
            Currency currency = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01),Currency=currency };
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            controller.SetExpense(expense);
            string type = ".txt";
            string fileName = "reporte";
            controller.ExportExpenseReport(controller.GetExpenses(), fileName, type);
        }

        [TestMethod]
        public void FindCategoryByName()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            CategoryController categoryController = new CategoryController(repository);
            categoryController.SetCategory(categoryFood);
            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            controller.SetExpense(expense);
            Category category=controller.FindCategoryByName("food");
            Assert.AreEqual(categoryFood, category);
        }

        [TestMethod]
        public void FindCurrencyByName()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            CurrencyController CurrencyController = new CurrencyController(repository);
            Currency currencyExpecet = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            CurrencyController.SetCurrency(currencyExpecet);
            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01),Currency=currencyExpecet };
            controller.SetExpense(expense);
            Currency Currency = controller.FindCurrencyByName("Dolar");
            Assert.AreEqual(currencyExpecet, Currency);
        }

        [TestMethod]
        public void GetCategories()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            CategoryController categoryController = new CategoryController(repository);
            categoryController.SetCategory(categoryFood);
            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            controller.SetExpense(expense);
            List<Category> categories = controller.GetCategories();
            List<Category> categoriesExpected = categoryController.GetCategories();
            Assert.AreEqual(categoriesExpected, categories);
        }

        [TestMethod]
        public void GetCurrencies()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            CurrencyController CurrencyController = new CurrencyController(repository);
            Currency currencyExpecet = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            CurrencyController.SetCurrency(currencyExpecet);
            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01), Currency = currencyExpecet };
            controller.SetExpense(expense);
            List<Currency> currenciesExpected = CurrencyController.GetCurrencies();
            List<Currency> currencies = controller.GetCurrencies();
            Assert.AreEqual(currenciesExpected, currencies);
        }

        [TestMethod]
        public void GetExpenseByDateExist()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            Currency currency = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Expense expenseExpected = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01), Currency = currency};
            controller.SetExpense(expenseExpected);
            List<Expense> expenses = controller.GetExpenseByDate("January", 2020);
           CollectionAssert.AreEqual(controller.GetExpenses(), expenses);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindExpenseByDate), "")]
        public void GetExpenseByDateNoExist()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            Currency currency = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Expense expenseExpected = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01), Currency = currency };
            controller.SetExpense(expenseExpected);
            List<Expense> expenses = controller.GetExpenseByDate("March", 2021);
            Assert.AreEqual(0, expenses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionExpenseWithEmptyCategory), "")]
        public void setExpenseWithEmptyCategory()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            Currency currency = new Currency() { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Expense expenseExpected = new Expense { Description = "movie theater", Amount = 24, Category = null, CreationDate = new DateTime(2020, 01, 01), Currency = currency };
            controller.SetExpense(expenseExpected);
        }

        [TestMethod]
        public void YearsOrderedInWhichAreExpenses()
        {

            List<int> years = new List<int>()
            {
             2020
            };
            List<int> yersOrder = expenseController.OrderedYearsWithExpenses();
            CollectionAssert.AreEqual(years, yersOrder);
        }

        [TestMethod]
        public void GetExpenseReport()
        {

            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);

            Currency currency = new Currency { Name = "Dolar", Symbol = "USD", Quotation = 1 };
            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01), Currency = currency };
            controller.SetExpense(expense);
            ExpenseReportLine expenseReportLine = new ExpenseReportLine()
            {
                Amount = expense.Amount,
                Category = expense.Category,
                CreationDate = expense.CreationDate,
                Description = expense.Description,
                Currency= expense.Currency
            };
            GenerateExpenseReport expenseReport = controller.GetExpenseReport("January", 2020);
            Assert.AreEqual(expenseReportLine, expenseReport.ExpenseReportLine.ToArray()[0]);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryValidCase()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            ExpenseController controller = new ExpenseController(repository);

            Expense expense = new Expense { Description = "movie theater", Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01), Currency = CurrencyPesos };
            controller.SetExpense(expense);

            double expectedTotalSpentJanuary = 24;
            double actualTotalSpentJanuary = controller.GetTotalSpentByDateAndCategory("January", categoryFood, 2020);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindExpenseByDate), "")]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpenses()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = expenseController.GetTotalSpentByDateAndCategory("March", categoryFood, 2020);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpensesInCategory()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = expenseController.GetTotalSpentByDateAndCategory("January", categoryHouse, 2020);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

    }
}
