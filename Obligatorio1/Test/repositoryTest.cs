using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RepositoryTest
    {
        private static List<string> keyWords1 = new List<string>();
        private static Repository repo = new Repository();
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static Budget JanuaryBudget;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            keyWords1 = new List<string>
            {
                "cine",
                "teatro",
                "casino"
            };
            categoryEntertainment = new Category()
            {
                Name = "entretenimiento",
                KeyWords = keyWords1
            };
            List<string> keyWords2 = new List<string>
            {
                "restaurante",
                "McDonalds",
                "cena"
            };
            categoryFood = new Category()
            {
                Name = "comida",
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
            repo.AddCategory(categoryEntertainment);
            repo.AddCategory(categoryFood);
            repo.AddCategory(categoryHouse);

            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };
            JanuaryBudget = new Budget(1, categories)
            {
                Year = 2020,
                TotalAmount = 0
            };
            repo.AddBudget(JanuaryBudget);

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
            repo.Expenses.Add(januaryExpenseFood);
            repo.Expenses.Add(januaryExpenseFood2);
            repo.Expenses.Add(januaryExpenseEntertainment);
        }      

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryInvalidAddingTwice()
        {
            Repository emptyRepository = new Repository();
            string categoryName = "Hogar";
            Category category = new Category { Name = categoryName };
            emptyRepository.AddCategory(category);
            emptyRepository.AddCategory(category);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryAlreadyUsedName()
        {
            string categoryName = "Entretenimiento";
            Category category2 = new Category { Name = categoryName };
            repo.AddCategory(category2);

        }

        [TestMethod]
        public void AddCategoryValidData()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>()
            {
                "cine",
                "sala de juegos",
            };
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            Repository repository = new Repository();
            repository.AddCategory(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>()
            {
                "restaurant",
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategory(category2);
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
            Repository repository = new Repository();
            String categoryName = "NameExample";
            List<string> keyWords = new List<string>
            {
                "cine",
                "teatro"
            };
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            repository.AddCategory(category);
            String categoryName2 = "NameExample2";
            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro"
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategory(category2);
            Assert.AreEqual(category, repository.Categories.ToArray()[0]);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            Repository repository = new Repository();

            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>()
            {
                "cine",
                "sala de juego",
            };
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            repository.AddCategory(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategory(category2);
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
            Budget validBudget = new Budget(DateTime.Now.Month) { 
                TotalAmount = 4000, 
                Year = DateTime.Now.Year 
            };
            Repository EmptyRepository = new Repository();
            EmptyRepository.AddBudget(validBudget);

            Budget currentBudget = EmptyRepository.Budgets.First();
            Assert.AreEqual(validBudget, currentBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidNullBudgetToRepository()
        {
            Budget invalidBudget = null;
            repo.AddBudget(invalidBudget);
        }

        [TestMethod]
        public void AddValidBudgetCategoryToRepository()
        {
            BudgetCategory validBudgetCategory = new BudgetCategory { 
                Category = categoryFood, 
                Amount = 1000 
            };
            Repository EmptyRepository = new Repository();
            EmptyRepository.AddBudgetCategory(validBudgetCategory);

            BudgetCategory currentBudgetCategory = EmptyRepository.BudgetCategories.First();
            Assert.AreEqual(validBudgetCategory, currentBudgetCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidNullBudgetCategoryToRepository()
        {
            BudgetCategory invalidBudgetCategory = null;
            repo.AddBudgetCategory(invalidBudgetCategory);
        }

        [TestMethod]
        public void CreateAddExpense()
        {
            Expense expectedExpense = new Expense { Amount = 23, CreationDate = new DateTime(2020, 01, 01), Description = "cena", Category = categoryFood };
            Repository repository = new Repository();
            repository.SetExpense(23, new DateTime(2020, 01, 01), "cena", categoryFood);
            Assert.AreEqual(expectedExpense, repository.Expenses.ToArray()[0]);
        }

        [TestMethod]
        public void CreateAddCategoty()
        {
            List<string> keyWords2 = new List<string>
            {
                "restaurante",
                "McDonalds",
                "cena"
            };
            Repository repository = new Repository();
            repository.SetCategory("comida", keyWords2);
            Assert.AreEqual(categoryFood, repository.Categories.ToArray()[0]);
        }



      
    }
}