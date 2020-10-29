using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MemoryRepositoryTest
    {
        private static List<string> keyWords1 = new List<string>();
        private static MemoryRepository repo = new MemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
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
            repo.SetCategory("entertainment", keyWords1);
            repo.SetCategory("food",keyWords2);
            repo.SetCategory("House",keyWords3);

            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };
            JanuaryBudget = new Budget(Months.January, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            repo.SetBudget(JanuaryBudget);

            Expense januaryExpenseFood = new Expense()
            {  
                Amount = 200,
                CreationDate = new DateTime(2020, 1, 1),
                Description = "sushi night",
                Category = categoryFood
            };
            Expense januaryExpenseFood2 = new Expense()
            {
                Amount = 110.50,
                CreationDate = new DateTime(2020, 1, 1),
                Description = "sushi night",
                Category = categoryFood
            };
            Expense januaryExpenseEntertainment = new Expense()
            {
                Amount = 230.15,
                CreationDate = new DateTime(2020, 1, 1),
                Description = "buy video game",
                Category = categoryEntertainment
            };
            repo.GetExpenses().Add(januaryExpenseFood);
            repo.GetExpenses().Add(januaryExpenseFood2);
            repo.GetExpenses().Add(januaryExpenseEntertainment);
        }      

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryInvalidAddingTwice()
        {
            MemoryRepository emptyRepository = new MemoryRepository();
            string categoryName = "house";
            Category category = new Category { Name = categoryName };
            emptyRepository.SetCategory(categoryName,new List<string>());
            emptyRepository.SetCategory(categoryName, new List<string>());

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryAlreadyUsedName()
        {
            string categoryName ="Entertainment";
            Category category2 = new Category { Name = categoryName };
            repo.SetCategory(categoryName,new List<string>());

        }

        [TestMethod]
        public void AddCategoryValidData()
        {
            String categoryName ="Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords)};
            MemoryRepository repository = new MemoryRepository();
            repository.SetCategory(categoryName, keyWords);
            String categoryName2 = "Food";
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2)};
            repository.SetCategory(categoryName2,keyWords2);
            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            CollectionAssert.AreEqual(categories, repository.GetCategories().ToArray());
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
            repository.SetCategory(categoryName,keyWords);
            String categoryName2 = "NameExample2";
            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater"
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2)};
            repository.SetCategory(categoryName2,keyWords2);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            MemoryRepository repository = new MemoryRepository();

            String categoryName ="Entertainment";
            List<string> keyWords = new List<string>()
            {
            "movie theater",
                "game room",
            };
            Category category = new Category { Name = categoryName, KeyWords = new KeyWord(keyWords) };
            repository.SetCategory(categoryName,keyWords);
            String categoryName2 ="Food";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category { Name = categoryName2, KeyWords = new KeyWord(keyWords2)};
            repository.SetCategory(categoryName2,keyWords2);
            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            CollectionAssert.AreEqual(categories, repository.GetCategories().ToArray());
        }
            

        [TestMethod]
        public void AddValidBudgetToRepository()
        {
            Budget validBudget = new Budget((Months) DateTime.Now.Month) { 
                TotalAmount = 4000, 
                Year = DateTime.Now.Year 
            };
            MemoryRepository EmptyRepository = new MemoryRepository();
            EmptyRepository.SetBudget(validBudget);

            Budget currentBudget = EmptyRepository.GetBudgets().First();
            Assert.AreEqual(validBudget, currentBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidNullBudgetToRepository()
        {
            Budget invalidBudget = null;
            repo.SetBudget(invalidBudget);
        }


        [TestMethod]
        public void CreateAddExpense()
        {
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            MemoryRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood);
            Assert.AreEqual(expectedExpense, repository.GetExpenses().ToArray()[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionExpenseWithEmptyCategory))]
        public void CreateAddExpenseCateogryNull()
        {
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner",Category=null };
            MemoryRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", null);
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
            repository.SetCategory("food", keyWords2);
            Assert.AreEqual(categoryFood, repository.GetCategories().ToArray()[0]);
        }

        [TestMethod]
        public void FindCategoryEntertainment()
        {
            string description = "movie theater";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.AreEqual(categoryEntertainment, expectedCategory);

        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultForEntertainment()
        {
            string description = "movie theater and CoffeMaker";
           repo.FindCategoryByDescription(description);
        }

        [TestMethod]
        [ExpectedException(typeof(NoAsignCategoryByDescriptionExpense), "")]
        public void FindCategoryNullValueResultFood()
        {
            string description = "";
           repo.FindCategoryByDescription(description);

        }

        [TestMethod]
        public void FindCategoryNullValueResultForFood()
        {
            string description = "cuando fuimos a comer a McDonalds";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.AreEqual(categoryFood, expectedCategory);

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
            repository.SetBudget(JanuaryBudget);
            Budget actualBudget = repository.FindBudget("January", 2020);
            Assert.AreEqual(JanuaryBudget, actualBudget);
        }


        [TestMethod]
        [ExpectedException(typeof(NoFindBudget), "")]
        public void FindBudgetNotFoundCase()
        {
            Budget actualBudget = repo.FindBudget("February", 2020);
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
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
                "McDonalds",
                "Dinner",

            };
            Category category2 = new Category { Name = "food", KeyWords = new KeyWord(keyWords2) };
            categoryList.Add(category1);
            categoryList.Add(category2);
            MemoryRepository respoitory = new MemoryRepository(categoryList);
            Category category3 = respoitory.FindCategoryByName("entertainment");
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
            MemoryRepository repository = new MemoryRepository(categoryList);
            repository.FindCategoryByName("entertainment");
        }

        [TestMethod]
        public void FindExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            MemoryRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01),description,categoryFood);
            Expense expectedExpense = repository.FindExpense(expense);
            Assert.AreEqual(expense, expectedExpense);


        }

        [TestMethod]
        public void FindEqualsExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Expense expense2 = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            MemoryRepository repository = new MemoryRepository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), description, categoryFood);
            Expense expectedExpense = repository.FindExpense(expense);
            Assert.AreEqual(expense, expectedExpense);

        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpense()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            Expense expense2 = new Expense { Description = description, Amount = 23, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            MemoryRepository repository = new MemoryRepository();
            repository.SetExpense(24, new DateTime(2020, 01, 01), description, categoryFood);
            Expense expectedExpense = repository.FindExpense(expense2);

        }

        [TestMethod]
        [ExpectedException(typeof(NoFindEqualsExpense), "")]
        public void FindNullExpenseEmtyRepository()
        {
            string description = "movie theater";
            Expense expense = new Expense { Description = description, Amount = 24, Category = categoryFood, CreationDate = new DateTime(2020, 01, 01) };
            MemoryRepository repository = new MemoryRepository();
            Expense expectedExpense = repository.FindExpense(expense);
            Assert.IsNull(expectedExpense);

        }

    }
}