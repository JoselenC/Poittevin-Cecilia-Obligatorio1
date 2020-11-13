using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ExpenseControllerTest
    {

        private static List<string> keyWords1 = new List<string>();
        private static IManageRepository repo = new MemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static ExpenseController expenseController;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            keyWords1 = new List<string>
            {
                "movie theater",
                "theater",
                "casino"
            };
            categoryEntertainment = new Category()
            {
                Name = "entertainment",
                KeyWords = new KeyWord(keyWords1)
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
                KeyWords = new KeyWord(keyWords2)
            };
            List<string> keyWords3 = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            categoryHouse = new Category()
            {
                Name = "House",
                KeyWords = new KeyWord(keyWords3)
            };
            repo.SetCategory("entertainment", keyWords1);
            repo.SetCategory("food", keyWords2);
            repo.SetCategory("house", keyWords3);
            repo.SetExpense(220, new DateTime(2020, 1, 1), "sushi night", categoryFood, null);
            repo.SetExpense(110.50, new DateTime(2020, 1, 1), "sushi night", categoryFood, null);
            repo.SetExpense(230.15, new DateTime(2020, 1, 1), "buy video game", categoryEntertainment, null);
            expenseController = new ExpenseController(repo);
        }

        [TestMethod]
        public void FindExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            IManageRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), description, categoryFood, null);
            ExpenseController controller = new ExpenseController(repository);
            Expense expectedExpense = controller.FindExpense(expense);
            Assert.AreEqual(expense, expectedExpense);
        }

        [TestMethod]
        public void FindEqualsExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Expense expense2 = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            IManageRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), description, categoryFood, null);
            ExpenseController controller = new ExpenseController(repository);
            Expense expectedExpense = controller.FindExpense(expense);
            Assert.AreEqual(expense, expectedExpense);

        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Expense expense2 = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            IManageRepository repository = new MemoryRepository();
            repository.SetExpense(24, new DateTime(2020, 01, 01), description, categoryFood, null);
            ExpenseController controller = new ExpenseController(repository);
            Expense expectedExpense = controller.FindExpense(expense2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpenseEmtyRepository()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            IManageRepository repository = new MemoryRepository();
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
            Category expectedCategory = expenseController.FindCategoryByDescription(description);

        }

        [TestMethod]
        public void FindCategoryValueResultForFood()
        {
            string description = "when we went to McDonalds last night";
            Category expectedCategory = expenseController.FindCategoryByDescription(description);
            Assert.AreEqual(categoryFood, expectedCategory);

        }

        [TestMethod]
        public void FindRemoveExpennse()
        {
            IManageRepository repository = new MemoryRepository();
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood, null);
            ExpenseController controller = new ExpenseController(repository);
            controller.DeleteExpense(expense);
            Assert.AreEqual(0, controller.GetExpenses().Count);
        }

        [TestMethod]
        public void MonthsOrderedInWhichAreExpenses()
        {

            List<string> months = new List<string>()
            {
            "January",
            "May",
            };
            DateTime month1 = new DateTime(2020, 1, 24);
            DateTime month5 = new DateTime(2020, 5, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "movie theater" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month5, Description = "movie theater" };
            IManageRepository repo = new MemoryRepository();
            repo.GetExpenses().Add(expense1);
            repo.GetExpenses().Add(expense2);
            ExpenseController controller = new ExpenseController(repo);
            List<string> monthsOrder = controller.OrderedMonthsWithExpenses();
            CollectionAssert.AreEqual(months, monthsOrder);


        }

        [TestMethod]
        public void ExpensesByMonth()
        {
            Months month = Months.January;
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            IManageRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            ExpenseController controller = new ExpenseController(repository);
            Assert.AreEqual(expense1, controller.GetExpenseByMonth(month).ToArray()[0]);

        }

        [TestMethod]
        public void ExpensesByMonthEmpty()
        {
            Months month = Months.May;
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            IManageRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            Assert.AreEqual(0, expenseController.GetExpenseByMonth(month).Count);
        }

        [TestMethod]
        public void ExpensesByMonthString()
        {
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 05, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            IManageRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            ExpenseController controller = new ExpenseController(repository);
            Assert.AreEqual(expense1, controller.GetExpenseByMonth("May").ToArray()[0]);

        }

        [TestMethod]
        public void ExpensesByMonthEmptyString()
        {
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            IManageRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            Assert.AreEqual(0, expenseController.GetExpenseByMonth("May").Count);
        }

        [TestMethod]
        public void FindCategoryByName()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>()
            {
               "movie theater",
               "theater",
               "casino",
            };
            Category category1 = new Category { Name = "entertainment", KeyWords = new KeyWord(keyWords1) };
            Category category3 = expenseController.FindCategoryByName("entertainment");
            Assert.AreEqual(category1, category3);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCategoryByName), "")]
        public void FindCategoryByNameNull()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>()
            {

               "movie theater",
               "theater",
               "casino",
            };
            Category category1 = new Category { Name = "fun", KeyWords = new KeyWord(keyWords1) };
            List<string> keyWords2 = new List<string>()
             {
                "restaurant",
                "McDonalds",
                "Dinner",
            };
            Category category2 = new Category { Name = "food", KeyWords = new KeyWord(keyWords2) };
            categoryList.Add(category1);
            categoryList.Add(category2);
            IManageRepository repo = new MemoryRepository(categoryList);
            ExpenseController controller = new ExpenseController(repo);
            Category category3 = controller.FindCategoryByName("entertainment");
            Assert.IsNull(category3);
        }

        [TestMethod]
        public void CreateAddExpense()
        {
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            IManageRepository repository = new MemoryRepository();
            ExpenseController controller = new ExpenseController(repository);
            controller.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood, null);
            Assert.AreEqual(expectedExpense, repository.GetExpenses().ToArray()[0]);
        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichIsAnExpense()
        {
            Months month = Months.August;
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23.5, CreationDate = month1, Description = "movie theater" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "movie theater" };
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            IManageRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            ExpenseController controller = new ExpenseController(repository);
            double totalAmount = controller.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "food" };
            List<Category> categories = new List<Category>();
            categories.Add(category);
            IManageRepository repository = new MemoryRepository(categories);
            ExpenseController controller = new ExpenseController(repository);
            List<Category> categories2 = controller.GetCategories();
            Assert.AreEqual(categories, categories2);
        }

        [TestMethod]
        public void FindcurrencyByName()
        {
            Currency currencyExpected = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            MemoryRepository repo = new MemoryRepository();
            repo.SetCurrency(currencyExpected);
            ExpenseController controller = new ExpenseController(repo);            
            Currency currency = controller.FindCurrencyByName("dolar");
            Assert.AreEqual(currency, currencyExpected);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCurrencyByName), "")]
        public void NoFindcurrencyByName()
        {
            Currency currencyExpected = new Currency { Name = "euro", Quotation = 43, Symbol = "USD" };
            MemoryRepository repo = new MemoryRepository();
            repo.SetCurrency(currencyExpected);
            ExpenseController controller = new ExpenseController(repo);
            controller.FindCurrencyByName("dolar");        
        }

        [TestMethod]
        public void GetMonies()
        {
            Currency currencyExpected = new Currency { Name = "dolar", Quotation = 43, Symbol = "USD" };
            Currency currency = new Currency() { Name = "Pesos", Symbol = "$U", Quotation = 1 };
            List<Currency> moniesExpected = new List<Currency>() {
                currency,
                currencyExpected,                
            };
            IManageRepository repo = new MemoryRepository();
            repo.SetMoney(moneyExpected);
            ExpenseController controller = new ExpenseController(repo);
            List<Currency> monies = controller.GetCurrencies();
            CollectionAssert.AreEqual(moniesExpected,monies);
        }
    }
}
