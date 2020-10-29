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
        private static MemoryRepository repo = new MemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static Budget JanuaryBudget;
        private static BudgetController logicController;

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
            logicController = new BudgetController(repo);
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
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "movie theater"};
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            MemoryRepository repository = new MemoryRepository();
            repository.GetExpenses().Add(expense1);
            repository.GetExpenses().Add(expense2);
            repository.GetExpenses().Add(expense3);
            double totalAmount = logicController.AmountOfExpensesInAMonth(month);
            Assert.AreEqual(0, totalAmount);

        }

       

        

       

        [TestMethod]
        [ExpectedException(typeof(ExcepcionExpenseWithEmptyCategory), "")]
        public void AddExpenseNullCategory()
        {
            DateTime month = new DateTime(2020, 1, 24);
            MemoryRepository repository = new MemoryRepository();
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
            MemoryRepository repository = new MemoryRepository();
            repository.AddExpense(expense);
            Assert.AreEqual(expense, repository.GetExpenses().ToArray()[0]);
        }

       

       

     

        


       

       


    }
}
