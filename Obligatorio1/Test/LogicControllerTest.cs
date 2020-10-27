using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class LogicControllerTest
    {
        private static List<string> keyWords1 = new List<string>();
        private static Repository repo = new Repository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static Budget JanuaryBudget;
        private static LogicController logicController;

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
                Name ="entertainment",
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
            repo.AddCategory(categoryEntertainment);
            repo.AddCategory(categoryFood);
            repo.AddCategory(categoryHouse);

            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };
            JanuaryBudget = new Budget(Months.January, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            repo.AddBudget(JanuaryBudget);            
            repo.SetExpense(220, new DateTime(2020, 1, 1), "sushi night",categoryFood);
            repo.SetExpense(110.50, new DateTime(2020, 1, 1), "sushi night", categoryFood);
            repo.SetExpense(230.15, new DateTime(2020, 1, 1), "buy video game", categoryEntertainment);
            logicController = new LogicController(repo);
        }

        [TestMethod]

        public void GetTotalSpentByMonthAndCategoryValidCase()
        {
            double expectedTotalSpentJanuary = 330.50;
            double actualTotalSpentJanuary = logicController.GetTotalSpentByMonthAndCategory("January", categoryFood);
            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpenses()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = logicController.GetTotalSpentByMonthAndCategory("March", categoryFood);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpensesInCategory()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary =logicController.GetTotalSpentByMonthAndCategory("January", categoryHouse);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsInAnotherCategory), "")]
        public void RepeatedKeyWordToCategory()
        {
            logicController.AlreadyExistKeyWordInAnoterCategory("movie theater");
        }

        [TestMethod]
        public void NoRepeatedKeyWordToCategory()
        {
            logicController.AlreadyExistKeyWordInAnoterCategory("bowling");
        }

        [TestMethod]
        public void FindExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Repository repository = new Repository();
            repository.AddExpense(expense);
            LogicController controller = new LogicController(repository);
            Expense expectedExpense = controller.FindExpense(expense);
            Assert.AreEqual(expense, expectedExpense);


        }

        [TestMethod]
        public void FindEqualsExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Expense expense2 = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Repository repository = new Repository();
            repository.AddExpense(expense);
            LogicController controller = new LogicController(repository);
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
            Repository repository = new Repository();
            repository.AddExpense(expense);
            LogicController controller = new LogicController(repository);
            Expense expectedExpense = controller.FindExpense(expense2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpenseEmtyRepository()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            Expense expectedExpense = controller.FindExpense(expense);
        }


        [TestMethod]
        public void BudgetGetOrCreateFindCase()
        {
            string expectedString = "month: January year: 2020 total: 0";
            string month = "January";
            int year = 2020;
            Budget budget = logicController.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedString, budget.ToString());
        }

        [TestMethod]
        public void BudgetGetOrCreateCreateCase()
        {
            string month = "December";
            int year = 2020;
            Budget expectedBudget = new Budget(Months.December, repo.GetCategories()) { 
                Year = 2020, 
                TotalAmount = 0 
            };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            Budget budget = logicController.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedBudget, budget);
        }

        [TestMethod]
        public void BudgetGetOrCreateAddAndFind()
        {
            Repository emptyRepository = new Repository();
            Months month = Months.December;
            int year = 2020;
            Budget budget = new Budget(month) { Year = year, TotalAmount = 0 };
            emptyRepository.AddBudget(budget);
            LogicController controller = new LogicController(emptyRepository);
            Budget actualBudget = controller.BudgetGetOrCreate("December", year);
            Assert.AreEqual(budget, actualBudget);
        }

        [TestMethod]
        public void BudgetGetOrCreateCheckCategories()
        {
            BudgetCategory budgetCategory = new BudgetCategory { 
                Category = categoryEntertainment,
                Amount = 0 
            };
            BudgetCategory budgetCategory2 = new BudgetCategory { 
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
            };
            Budget actualBudget = logicController.BudgetGetOrCreate("January", 2020);
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
            Repository repository = new Repository();
            repository.AddBudget(JanuaryBudget);
            LogicController controller = new LogicController(repository);
            Budget actualBudget = controller.FindBudget("January", 2020);
            Assert.AreEqual(JanuaryBudget, actualBudget);
        }


        [TestMethod]
        [ExpectedException(typeof(NoFindBudget), "")]
        public void FindBudgetNotFoundCase()
        {
            Budget actualBudget = logicController.FindBudget("February", 2020);
        }

        [TestMethod]
        public void FindRemoveExpennse()
        {            
            Repository repository = new Repository();
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            repository.AddExpense(expense);
            LogicController controller = new LogicController(repository);
            controller.DeleteExpense(expense);
            Assert.AreEqual(0, controller.GetExpenses().Count);
        }
        [TestMethod]
        public void FindCategoryEntertainment()
        {
            string description = "movie theater";
            Category expectedCategory = logicController.FindCategoryByDescription(description);
            Assert.AreEqual(categoryEntertainment, expectedCategory);

        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultForEntertainment()
        {
            string description = "movie theater and CoffeMaker";
            Category expectedCategory = logicController.FindCategoryByDescription(description);
        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultFood()
        {
            string description =""; 
            Category expectedCategory = logicController.FindCategoryByDescription(description);           

        }

        [TestMethod]
        public void FindCategoryValueResultForFood()
        {
            string description ="when we went to McDonalds last night";
            Category expectedCategory = logicController.FindCategoryByDescription(description);
            Assert.AreEqual(categoryFood, expectedCategory);

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
            Repository repo = new Repository();
            repo.GetExpenses().Add(expense1);
            repo.GetExpenses().Add(expense2);
            LogicController controller = new LogicController(repo);
            List<string> monthsOrder = controller.OrderedMonthsWithExpenses();
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
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            LogicController controller = new LogicController(repository);
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
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "movie theater"};
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            double totalAmount = logicController.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(0, totalAmount);

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
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            LogicController controller = new LogicController(repository);
            double totalAmount = controller.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpensesByMonth()
        {
            Months month = Months.January;
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            LogicController controller = new LogicController(repository);
            Assert.AreEqual(expense1, controller.GetExpenseByMonth(month).ToArray()[0]);

        }

        [TestMethod]
        public void ExpensesByMonthEmpty()
        {
            Months month = Months.May;
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            Assert.AreEqual(0, logicController.GetExpenseByMonth(month).Count);
        }

        [TestMethod]
        public void ExpensesByMonthString()
        {           
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 05, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            LogicController controller = new LogicController(repository);
            Assert.AreEqual(expense1, controller.GetExpenseByMonth("May").ToArray()[0]);

        }

        [TestMethod]
        public void ExpensesByMonthEmptyString()
        {
            Expense expense1 = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "when we go movies" };
            Expense expense2 = new Expense { Amount = 19, CreationDate = new DateTime(2020, 11, 01), Description = "when we go movies" };
            Repository repository = new Repository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            Assert.AreEqual(0, logicController.GetExpenseByMonth("May").Count);
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
            Category category3 = logicController.FindCategoryByName("entertainment");
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
            Category category1 = new Category { Name ="fun", KeyWords = new KeyWord(keyWords1) };
            List<string> keyWords2 = new List<string>()
             {
                "restaurant",
                "McDonalds",
                "Dinner",
            };
            Category category2 = new Category { Name = "food", KeyWords = new KeyWord(keyWords2) };
            categoryList.Add(category1);
            categoryList.Add(category2);
            Repository repo = new Repository(categoryList);
            LogicController controller = new LogicController(repo);
            Category category3 = controller.FindCategoryByName("entertainment");
            Assert.IsNull(category3);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionExpenseWithEmptyCategory), "")]
        public void AddExpenseNullCategory()
        {
            DateTime month = new DateTime(2020, 1, 24);
            Repository repository = new Repository();
            Expense expense = new Expense { Amount = 23.5, CreationDate = month, Description = "movie theater" };
            repository.AddExpense(expense);
        }

        [TestMethod]
        public void AddExpenseValidData()
        {
            String categoryName = "Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "theater",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords)};
            List<Category> categories = new List<Category>();
            categories.Add(category);
            DateTime month = new DateTime(2020, 1, 24);
            Expense expense = new Expense { Amount = 23.5, CreationDate = month, Description = "movie theater"};
            expense.Category = category;
            Repository repository = new Repository();
            repository.AddExpense(expense);
            Assert.AreEqual(expense, repository.GetExpenses().ToArray()[0]);
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
            string[] allMonths = logicController.GetAllMonthsString();
            CollectionAssert.AreEqual(allMonths, expectedMonthStrings);
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
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetCategory("food", keyWords2);
            Assert.AreEqual(categoryFood, repository.GetCategories().ToArray()[0]);
        }
        [TestMethod]
        public void CreateAddExpense()
        {
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood);
            Assert.AreEqual(expectedExpense, repository.GetExpenses().ToArray()[0]);
        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "food" };
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            LogicController controller = new LogicController(repository);
            List<Category> categories2 = controller.GetCategories();
            Assert.AreEqual(categories, categories2);
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
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetCategory(categoryName, keyWords);
            String categoryName2 = "food";
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2)};
            controller.SetCategory(categoryName2,keyWords2);
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
            Repository repository = new Repository();
            String categoryName = "NameExample";
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater"
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            LogicController controller = new LogicController(repository);
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
            Repository repository = new Repository();

            String categoryName = "Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            LogicController controller = new LogicController(repository);
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
        public void AddValidBudgetToRepository()
        {
            Budget validBudget = new Budget((Months) DateTime.Now.Month)
            {
                TotalAmount = 4000,
                Year = DateTime.Now.Year
            };
            Repository EmptyRepository = new Repository();
            LogicController controller = new LogicController(EmptyRepository);
            controller.SetBudget(validBudget);
            Budget currentBudget =controller.Repository.GetBudgets().First();
            Assert.AreEqual(validBudget, currentBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidNullBudgetToRepository()
        {
            Budget invalidBudget = null;
            logicController.SetBudget(invalidBudget);
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
            Repository repo = new Repository();
            repo.GetBudgets().Add(budget1);
            repo.GetBudgets().Add(budget2);
            LogicController controller = new LogicController(repo);
            List<string> monthsOrder = controller.OrderedMonthsWithBudget();
            CollectionAssert.AreEqual(months, monthsOrder);

        }

        [TestMethod]
        public void EditCategoryExpense()
        {
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryEntertainment };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetExpense(23, new DateTime(2020, 01, 01),"dinner",categoryFood);
            List <string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "casino"
            };
            controller.EditCategory(categoryFood, "entertainment", keyWords);
            CollectionAssert.Equals(expectedExpense, expense);
        }

        [TestMethod]
        public void NoEditCategoryExpense()
        {
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood);
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater",
                "casino"
            };
            controller.EditCategory(categoryFood, "dinner", keyWords);
            CollectionAssert.Equals(expectedExpense, expense);
        }

        [TestMethod]
        public void EditCategoryBudget()
        {
            List<Category> categories = new List<Category>
            {
                categoryEntertainment,
                categoryFood,
            };
            Budget budget = new Budget(Months.December, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            List<Category> categories2 = new List<Category>
            {
                categoryEntertainment,
                categoryHouse
            };
            Budget expectedBudget = new Budget(Months.December, categories2)
            {
                Year = 2020,
                TotalAmount = 0
            };
            List<string> keyWords = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetBudget(budget); 
            controller.EditCategory(categoryFood, "House", keyWords);
            CollectionAssert.Equals(expectedBudget, budget);
        }

        [TestMethod]
        public void NoEditCategoryBudget()
        {
            List<Category> categories = new List<Category>
            {
                categoryEntertainment,
                categoryFood,
            };
            Budget budget = new Budget(Months.December, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            List<string> keyWords = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            Repository repository = new Repository();
            LogicController controller = new LogicController(repository);
            controller.SetBudget(budget);
            controller.EditCategory(categoryFood, "House", keyWords);
            CollectionAssert.Equals(budget, budget);
        }

        [TestMethod]
        public void GetBudgets()
        {
            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };            
            JanuaryBudget = new Budget(Months.January, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            List<Budget> budgets = new List<Budget>()
            {
                 JanuaryBudget
            };
            CollectionAssert.AreEqual(budgets,logicController.GetBudgets());
        }

    }
}
