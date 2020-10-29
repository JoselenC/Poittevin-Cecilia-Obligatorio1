using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class BudgetControllerTest
    {
        private static List<string> keyWords1 = new List<string>();
        private static MemoryRepository repo = new MemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static BudgetController budgetController;
        private static Budget JanuaryBudget;


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
            repo.AddBudget(JanuaryBudget);
            repo.AddCategory(categoryEntertainment);
            repo.AddCategory(categoryFood);
            repo.AddCategory(categoryHouse);
            repo.SetExpense(220, new DateTime(2020, 1, 1), "sushi night", categoryFood);
            repo.SetExpense(110.50, new DateTime(2020, 1, 1), "sushi night", categoryFood);
            repo.SetExpense(230.15, new DateTime(2020, 1, 1), "buy video game", categoryEntertainment);
            budgetController = new BudgetController(repo);
        }
        
        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryValidCase()
        {
            double expectedTotalSpentJanuary = 330.50;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("January", categoryFood);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpenses()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("March", categoryFood);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpensesInCategory()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = budgetController.GetTotalSpentByMonthAndCategory("January", categoryHouse);
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
            string month = "December";
            int year = 2020;
            Budget expectedBudget = new Budget(Months.December)
            {
                Year = 2020,
                TotalAmount = 0
            };
            MemoryRepository repository = new MemoryRepository();
            BudgetController controller = new BudgetController(repository);
            Budget budget = controller.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedBudget, budget);
        }

        [TestMethod]
        public void BudgetGetOrCreateAddAndFind()
        {
            MemoryRepository emptyRepository = new MemoryRepository();
            Months month = Months.December;
            int year = 2020;
            Budget budget = new Budget(month) { Year = year, TotalAmount = 0 };
            emptyRepository.AddBudget(budget);
            BudgetController controller = new BudgetController(emptyRepository);
            Budget actualBudget = controller.BudgetGetOrCreate("December", year);
            Assert.AreEqual(budget, actualBudget);
        }

        [TestMethod]
        public void BudgetGetOrCreateCheckCategories()
        {
            BudgetCategory budgetCategory = new BudgetCategory
            {
                Category = categoryEntertainment,
                Amount = 0
            };
            BudgetCategory budgetCategory2 = new BudgetCategory
            {
                Category = categoryFood,
                Amount = 0
            };
            BudgetCategory budgetCategory3 = new BudgetCategory
            {
                Category = categoryHouse,
                Amount = 0
            };
            List<BudgetCategory> budgetCategories = new List<BudgetCategory>() {
            budgetCategory,
            budgetCategory2,
            budgetCategory3
            };
            Budget actualBudget = budgetController.BudgetGetOrCreate("January", 2020);
            List<BudgetCategory> actualBudgetCategories = actualBudget.BudgetCategories;
            CollectionAssert.AreEqual(budgetCategories, actualBudgetCategories);
        }

        [TestMethod]
        public void FindBudgetFoundCase()
        {
            JanuaryBudget = new Budget(Months.January)
            {
                Year = 2020,
                TotalAmount = 0
            };
            MemoryRepository repository = new MemoryRepository();
            repository.AddBudget(JanuaryBudget);
            BudgetController controller = new BudgetController(repository);
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
            MemoryRepository EmptyRepository = new MemoryRepository();
            BudgetController controller = new BudgetController(EmptyRepository);
            controller.SetBudget(validBudget);
            Budget currentBudget = controller.GetBudgets().First();
            Assert.AreEqual(validBudget, currentBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidNullBudgetToRepository()
        {
            Budget invalidBudget = null;
            budgetController.SetBudget(invalidBudget);
        }

        [TestMethod]
        public void MonthsOrderedInWhichAreBudget()
        {
            List<string> months = new List<string>()
            {
            "January",
            "May",
            };
            Budget budget1 = new Budget(Months.January) { TotalAmount = 23, Year = 2020 };
            Budget budget2 = new Budget(Months.May) { TotalAmount = 23, Year = 2020 };
            MemoryRepository repo = new MemoryRepository();
            repo.GetBudgets().Add(budget1);
            repo.GetBudgets().Add(budget2);
            BudgetController controller = new BudgetController(repo);
            List<string> monthsOrder = controller.OrderedMonthsWithBudget();
            CollectionAssert.AreEqual(months, monthsOrder);
        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichAreExpenses()
        {
            Months month = Months.August;

            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 8, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "movie theater" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "movie theater" };
            Expense expense3 = new Expense { Amount = 23, CreationDate = month3, Description = "casino" };
            MemoryRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            BudgetController controller = new BudgetController(repository);
            double totalAmount = controller.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(46, totalAmount);
        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichAreNoExpenses()
        {
            Months month = Months.August;
            DateTime month1 = new DateTime(2020, 2, 24);
            DateTime month2 = new DateTime(2020, 3, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "movie theater" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "movie theater" };
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            MemoryRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            double totalAmount = budgetController.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(0, totalAmount);
        }

        [TestMethod]
        public void CreateAddCategoty()
        {
            List<string> keyWords2 = new List<string>
            {
                "restaurant",
                "McDonalds",
                "Dinner"
            };
            MemoryRepository repository = new MemoryRepository();
            repository.AddBudget(JanuaryBudget);
            BudgetController controller = new BudgetController(repository);
            controller.SetCategory("food", keyWords2);
            Assert.AreEqual(categoryFood, repository.GetCategories().ToArray()[0]);
        }

        [TestMethod]
        public void AddCategoryValidData()
        {
            String categoryName = "Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            MemoryRepository repository = new MemoryRepository();
            BudgetController controller = new BudgetController(repository);
            controller.SetCategory(categoryName, keyWords);
            String categoryName2 = "food";
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2) };
            controller.SetCategory(categoryName2, keyWords2);
            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            CollectionAssert.AreEqual(categories, controller.GetCategories().ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsCategory), "")]
        public void AddCategoryInvalidKeyWords()
        {
            MemoryRepository repository = new MemoryRepository();
            String categoryName = "NameExample";
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater"
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            BudgetController controller = new BudgetController(repository);
            controller.SetCategory(categoryName, keyWords);
            String categoryName2 = "NameExample2";
            List<string> keyWords2 = new List<string>
            {
                 "movie theater",
                "theater"
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2) };
            controller.SetCategory(categoryName2, keyWords2);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            MemoryRepository repository = new MemoryRepository();

            String categoryName = "Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            BudgetController controller = new BudgetController(repository);
            controller.SetCategory(categoryName, keyWords);
            String categoryName2 = "food";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2) };
            controller.SetCategory(categoryName2, keyWords2);
            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            CollectionAssert.AreEqual(categories, controller.GetCategories().ToArray());
        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "food" };
            List<Category> categories = new List<Category>();
            categories.Add(category);
            MemoryRepository repository = new MemoryRepository(categories);
            BudgetController controller = new BudgetController(repository);
            List<Category> categories2 = controller.GetCategories();
            Assert.AreEqual(categories, categories2);
        }


    }
}
