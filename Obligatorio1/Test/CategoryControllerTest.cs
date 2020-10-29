using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class CategoryControllerTest
    {

        private static List<string> keyWords1 = new List<string>();
        private static MemoryRepository repo = new MemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static CategoryController categoryController;

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
            repo.AddCategory(categoryEntertainment);
            repo.AddCategory(categoryFood);
            repo.AddCategory(categoryHouse);
            categoryController = new CategoryController(repo);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsInAnotherCategory), "")]
        public void RepeatedKeyWordToCategory()
        {
            categoryController.AlreadyExistKeyWordInAnoterCategory("movie theater");
        }

        [TestMethod]
        public void NoRepeatedKeyWordToCategory()
        {
            categoryController.AlreadyExistKeyWordInAnoterCategory("bowling");
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
            Category category3 = categoryController.FindCategoryByName("entertainment");
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
            MemoryRepository repo = new MemoryRepository(categoryList);
            CategoryController controller = new CategoryController(repo);
            Category category3 = controller.FindCategoryByName("entertainment");
            Assert.IsNull(category3);
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
            CategoryController controller = new CategoryController(repository);
            controller.SetCategory("food", keyWords2);
            Assert.AreEqual(categoryFood, repository.GetCategories().ToArray()[0]);
        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "food" };
            List<Category> categories = new List<Category>();
            categories.Add(category);
            MemoryRepository repository = new MemoryRepository(categories);
            CategoryController controller = new CategoryController(repository);
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
            MemoryRepository repository = new MemoryRepository();
            CategoryController controller = new CategoryController(repository);
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
            CategoryController controller = new CategoryController(repository);
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
            CategoryController controller = new CategoryController(repository);
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
        public void EditCategoryExpense()
        {
            Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryEntertainment };
            MemoryRepository repository = new MemoryRepository();
            CategoryController controller = new CategoryController(repository);
            controller.Repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood);
            List<string> keyWords = new List<string>
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
            MemoryRepository repository = new MemoryRepository();
            CategoryController controller = new CategoryController(repository);
            controller.Repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood);
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
            MemoryRepository repository = new MemoryRepository();
            CategoryController controller = new CategoryController(repository);
            controller.Repository.AddBudget(budget);
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
            MemoryRepository repository = new MemoryRepository();
            CategoryController controller = new CategoryController(repository);
            controller.Repository.AddBudget(budget);
            controller.EditCategory(categoryFood, "House", keyWords);
            CollectionAssert.Equals(budget, budget);
        }

    }
}
