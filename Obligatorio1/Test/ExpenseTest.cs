using BusinessLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ExpenseTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]

        public void createEmptyExpense()
        {

            double amount = 0;
            string description = "";
            DateTime creationDate = new DateTime(2020, 01, 01); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);

        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseNegativeAmount()
        {

            double amount = -10.5;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseInvalidAmount()
        {

            double amount = 23.555;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]

        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createExpenseInvalidAmount2()
        {

            double amount = 23.344;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01); 
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2031, 01, 01); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear2()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2017, 2, 2); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "")]
        public void creatExpenseInvalidDateYear3()
        {
            double amount = 23;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(0, 01, 01); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void creatExpenseInvalidDescription2()
        {
            double amount = 23;
            string description = "cuando fuimos al cine de punta carretas";
            DateTime creationDate = new DateTime(2021, 2, 2); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void creatExpenseInvalidDescription()
        {
            double amount = 23;
            string description = "aa";
            DateTime creationDate = new DateTime(2021, 2, 2); String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
        }

        [TestMethod]
        public void creatExpense()
        {
            double amount = 23.55;
            string description = "cuando fui al cine";
            DateTime creationDate = new DateTime(2020, 01, 01);
            String categoryName = "entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            keyWords.Add("salida");
            keyWords.Add("libreria");
            keyWords.Add("jugeteria");
            keyWords.Add("shopping");
            keyWords.Add("patinaje");
            keyWords.Add("casino");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            Repository repository = new Repository(categories);
            Expense expense = new Expense(amount, creationDate, description, repository);
            Assert.AreEqual(expense.Amount, amount);
            Assert.AreEqual(expense.CreationDate, creationDate);
            Assert.AreEqual(expense.Description, description);
            Assert.AreEqual(expense.Category, category);
        }

        }

       
        
        }


}
