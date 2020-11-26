using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Repository;
using DataAcces;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class CategoryControllerTest
    {

        private static List<string> keyWords1 = new List<string>();
        private static ManagerRepository repo = new ManageMemoryRepository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static CategoryController categoryController;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            categoryController = new CategoryController(repo);

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
                KeyWords =keyWords2
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
            categoryController.SetCategory("entertainment", keyWords1);
            categoryController.SetCategory("Food",keyWords2);
            categoryController.SetCategory("House",keyWords3);
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
            List<string> keyWords1 = new List<string>()
            {
               "movie theater",
               "theater",
               "casino",
            };
            Category category1 = new Category { Name = "entertainment", KeyWords = keyWords1 };
            Category category3 = categoryController.FindCategoryByName("Entertainment");
            Assert.AreEqual(category1, category3);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCategoryByName), "")]
        public void FindCategoryByNameNull()
        {
            ManagerRepository repo = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repo);

            
            List<string> keyWords1 = new List<string>()
            {

               "movie theater",
               "theater",
               "casino",
            };
           
            List<string> keyWords2 = new List<string>()
             {
                "restaurant",
                "McDonalds",
                "Dinner",
            };
            Category category1 = new Category { Name = "fun", KeyWords = keyWords1 };
            Category category2 = new Category { Name = "food", KeyWords = keyWords2 };
            List<Category> categoryList = new List<Category>();
            controller.SetCategory(category1);
            controller.SetCategory(category2);
            Category category3 = controller.FindCategoryByName("Entertainment");
            Assert.IsNull(category3);
        }

        [TestMethod]
        public void CreateAddCategoty()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);
            List<string> keyWords2 = new List<string>
            {
                "restaurant",
                "McDonalds",
                "Dinner"
            };
            Category category = new Category()
            {
                Name = "food",
                KeyWords = keyWords2
            };
            controller.SetCategory(category);
            Assert.AreEqual(categoryFood, controller.GetCategories()[0]);
        }

        [TestMethod]
        public void GetCategories()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);

            Category category = new Category { Name = "food" };
            List<Category> categories = new List<Category>
            {
                category
            };
            controller.SetCategory(category);
            List<Category> categories2 = controller.GetCategories();
            CollectionAssert.AreEqual(categories, categories2);
        }


        [TestMethod]
        public void AddCategoryValidData()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);

            string categoryName = "Entertainment";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            
           
            string categoryName2 = "food";
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
            };

            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            controller.SetCategory(category);
            controller.SetCategory(category2);
            CollectionAssert.AreEqual(categories, controller.GetCategories());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsCategory), "")]
        public void AddCategoryInvalidKeyWords()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);

            string categoryName = "NameExample";
            string categoryName2 = "NameExample2";
            List<string> keyWords = new List<string>
            {
                "movie theater",
                "theater"
            };
            List<string> keyWords2 = new List<string>
            {
                "movie theater",
                "theater"
            };

            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };

            controller.SetCategory(category);
            controller.SetCategory(category2);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);

            string categoryName = "Entertainment";
            string categoryName2 = "food";
            List<string> keyWords = new List<string>()
            {
                "movie theater",
                "game room",
            };
            List<string> keyWords2 = new List<string>
            {
                "restaurant"
            };
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };

            controller.SetCategory(categoryName, keyWords);
            controller.SetCategory(categoryName2, keyWords2);

            List<Category> categories = new List<Category>()
            {
                category,
                category2
            };
            CollectionAssert.AreEqual(categories, controller.GetCategories());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryInvalidName()
        {
            Category categoryEntertainment = new Category()
            {
                Name = "entertainment",
            }; 
            categoryController.SetCategory(categoryEntertainment);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateCategory()
        {
            ManagerRepository repository = new ManageMemoryRepository();
            CategoryController controller = new CategoryController(repository);
            List<string> keyWords = new List<string> { "restaurant", "McDonalds", "Dinner" };
            controller.SetCategory("food", keyWords);
            List<string> keyWords2 = new List<string> { "movie theater", "theater", "casino" };
            Category oldCategory = new Category() { Name = "food", KeyWords = keyWords };
            Category newCategory = new Category() { Name = "entertainment", KeyWords = keyWords2 };
            List<Category> categories = new List<Category>() { newCategory };
            controller.UpdateCategory(oldCategory, newCategory);
            Assert.Equals(controller.GetCategories(), categories);
        }


    }

    //[TestMethod]
    //public void EditCategoryExpense()
    //{
    //    Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
    //    Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryEntertainment };
    //    IManageRepository repository = new ManageMemoryRepository();
    //    CategoryController controller = new CategoryController(repository);
    //    controller.Repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood,null);
    //    List<string> keyWords = new List<string>
    //    {
    //        "movie theater",
    //        "theater",
    //        "casino"
    //    };
    //    controller.EditCategory(categoryFood, "entertainment", keyWords);
    //    CollectionAssert.Equals(expectedExpense, expense);
    //}

    //[TestMethod]
    //public void NoEditCategoryExpense()
    //{
    //    Expense expense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
    //    Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "dinner", Category = categoryFood };
    //    IManageRepository repository = new ManageMemoryRepository();
    //    CategoryController controller = new CategoryController(repository);
    //    controller.Repository.SetExpense(23, new DateTime(2020, 01, 01), "dinner", categoryFood,null);
    //    List<string> keyWords = new List<string>
    //    {
    //        "movie theater",
    //        "theater",
    //        "casino"
    //    };
    //    controller.EditCategory(categoryFood, "dinner", keyWords);
    //    CollectionAssert.Equals(expectedExpense, expense);
    //}

    //[TestMethod]
    //public void EditCategoryBudget()
    //{
    //    List<Category> categories = new List<Category>
    //    {
    //        categoryEntertainment,
    //        categoryFood,
    //    };
    //    Budget budget = new Budget(Months.December, categories)
    //    {
    //        Year = 2020,
    //        TotalAmount = 0
    //    };
    //    List<Category> categories2 = new List<Category>
    //    {
    //        categoryEntertainment,
    //        categoryHouse
    //    };
    //    Budget expectedBudget = new Budget(Months.December, categories2)
    //    {
    //        Year = 2020,
    //        TotalAmount = 0
    //    };
    //    List<string> keyWords = new List<string>
    //    {
    //        "CoffeMaker",
    //        "toilet paper",
    //    };
    //    IManageRepository repository = new ManageMemoryRepository();
    //    CategoryController controller = new CategoryController(repository);
    //    controller.Repository.SetBudget(budget);
    //    controller.EditCategory(categoryFood, "House", keyWords);
    //    CollectionAssert.Equals(expectedBudget, budget);
    //}

    //[TestMethod]
    //public void NoEditCategoryBudget()
    //{
    //    List<Category> categories = new List<Category>
    //    {
    //        categoryEntertainment,
    //        categoryFood,
    //    };
    //    Budget budget = new Budget(Months.December, categories)
    //    {
    //        Year = 2020,
    //        TotalAmount = 0
    //    };
    //    List<string> keyWords = new List<string>
    //    {
    //        "CoffeMaker",
    //        "toilet paper",
    //    };
    //    IManageRepository repository = new ManageMemoryRepository();
    //    CategoryController controller = new CategoryController(repository);
    //    controller.Repository.SetBudget(budget);
    //    controller.EditCategory(categoryFood, "House", keyWords);
    //    CollectionAssert.Equals(budget, budget);
    //}

}

