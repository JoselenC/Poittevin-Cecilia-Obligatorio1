﻿using System;
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
            categoryEntertainment = new Category { Name = "entretenimiento", KeyWords = keyWords1 };
            List<string> keyWords2 = new List<string>
            {
                "restaurante",
                "McDonalds",
                "cena"
            };
            categoryFood = new Category { Name = "comida", KeyWords = keyWords2 };
            repo.AddCategoryToCategories(categoryEntertainment);
            repo.AddCategoryToCategories(categoryFood);

            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };
            JanuaryBudget = new Budget(1, 2020, 0, categories);
            repo.AddBudget(JanuaryBudget);
        }

        [TestMethod]
        public void FindCategoryEntertainment()
        {
            string description = "cuando fuimos al cine";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.AreEqual(categoryEntertainment, expectedCategory);

        }

        [TestMethod]
        public void FindCategoryNullValueResultForEntertainment()
        {
            string description = "noche de videojuegos";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.IsNull(expectedCategory);
        }

        [TestMethod]
        public void FindCategoryNullValueResultFood()
        {
            string description = "cuando fuimos a comer";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.IsNull(expectedCategory);

        }

        [TestMethod]
        public void FindCategoryNullValueResultForFood()
        {
            string description = "cuando fuimos a comer a McDonalds";
            Category expectedCategory = repo.FindCategoryByDescription(description);
            Assert.AreEqual(categoryFood, expectedCategory);

        }

        [TestMethod]
        public void MonthsOrdered()
        {

            List<string> months = new List<string>();
            List<Expense> expenses = new List<Expense>();
            months.Add("Enero");
            months.Add("Mayo");
            DateTime month1 = new DateTime(2020, 1, 24);
            DateTime month5 = new DateTime(2020, 5, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month5, Description = "cine" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.OrderedMonthsInWhichThereAreExpenses();
            for (int i = 0; i < months.Count; i++)
            {
                Assert.AreEqual(months[i], monthsOrder[i]);
            }
        }

        [TestMethod]
        public void MonthsOrdered2()
        {

            List<string> months = new List<string>();
            List<Expense> expenses = new List<Expense>();
            months.Add("Enero");
            DateTime month1 = new DateTime(2020, 1, 24);
            DateTime month5 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month5, Description = "cine" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.OrderedMonthsInWhichThereAreExpenses();
            for (int i = 0; i < months.Count; i++)
            {
                Assert.AreEqual(months[i], monthsOrder[i]);
            }
        }

        [TestMethod]
        public void MonthsOrdered3()
        {

            List<string> months = new List<string>();
            List<Expense> expenses = new List<Expense>();
            months.Add("Enero");
            months.Add("Mayo");
            months.Add("Agosto");
            DateTime month8 = new DateTime(2020, 8, 24);
            DateTime month5 = new DateTime(2020, 5, 24);
            DateTime month1 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month8, Description = "cine" };
            Expense expense3 = new Expense { Amount = 23, CreationDate = month5, Description = "cine" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.OrderedMonthsInWhichThereAreExpenses();
            for (int i = 0; i < months.Count; i++)
            {
                Assert.AreEqual(months[i], monthsOrder[i]);
            }
        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichAreExpenses()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 8, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "cine" };
            Expense expense3 = new Expense { Amount = 23, CreationDate = month3, Description = "casino" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpensesByMonth(month);
            Assert.AreEqual(46, totalAmount);

        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichAreNoExpenses()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 2, 24);
            DateTime month2 = new DateTime(2020, 3, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "cine" };
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpensesByMonth(month);
            Assert.AreEqual(0, totalAmount);

        }

        [TestMethod]
        public void ExpenseAmountByMonthInWhichIsAnExpense()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense { Amount = 23.5, CreationDate = month1, Description = "cine" };
            Expense expense2 = new Expense { Amount = 23, CreationDate = month2, Description = "cine" };
            Expense expense3 = new Expense { Amount = 21, CreationDate = month3, Description = "casino" };
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpensesByMonth(month);
            Assert.AreEqual(23.5, totalAmount);

        }      

        [TestMethod]
        public void ExpenseReport()
        {
            List<string[]> reports = new List<string[]>();
            string[] report = new string[4];
            report[0] = "24/12/2020";
            report[1] = "cine";
            report[2] = "Entretenimiento";
            report[3] = "230";
            reports.Add(report);
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 12, 24);
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Repository repository = new Repository();
            Expense expense = new Expense { Amount = 230, CreationDate = month1, Description = "cine" };            
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            expense.Category = category;
            repository.AddCategoryToCategories(category);
            repository.AddExpenseToExpenses(expense);
            List<string[]> reports1 = repository.ExpenseReport(month1.Month.ToString());
            Assert.AreEqual(reports.ToArray()[0][0], reports1.ToArray()[0][0]);
            Assert.AreEqual(reports.ToArray()[0][1], reports1.ToArray()[0][1]);
            Assert.AreEqual(reports.ToArray()[0][2], reports1.ToArray()[0][2]);
            Assert.AreEqual(reports.ToArray()[0][3], reports1.ToArray()[0][3]);
        }



        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryInvalidAddingTwice()
        {
            Repository emptyRepository = new Repository();
            string categoryName = "Hogar";
            Category category = new Category { Name = categoryName };
            emptyRepository.AddCategoryToCategories(category);
            emptyRepository.AddCategoryToCategories(category);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryAlreadyUsedName()
        {
            string categoryName = "Entretenimiento";
            Category category2 = new Category { Name = categoryName };
            repo.AddCategoryToCategories(category2);

        }

        [TestMethod]
        public void AddCategoryValidName()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            Repository repository = new Repository();
            repository.AddCategoryToCategories(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            keyWords2.Add("cena"); 
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategoryToCategories(category2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(category2.Name, repository.Categories.ToArray()[1].Name);
            Assert.AreEqual(category2.KeyWords, repository.Categories.ToArray()[1].KeyWords);
            Assert.AreEqual(2, repository.Categories.Count);
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
            repository.AddCategoryToCategories(category);
            String categoryName2 = "NameExample2";
            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro"
            };
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategoryToCategories(category2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedKeyWordsCategory), "")]
        public void AddCategoryInvalidKeyWords2()
        {
            Repository repository = new Repository();

            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            repository.AddCategoryToCategories(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("Cine");
            keyWords2.Add("Restaurante");
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2};
            repository.AddCategoryToCategories(category2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            Repository repository = new Repository();

            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            repository.AddCategoryToCategories(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category { Name = categoryName2, KeyWords = keyWords2 };
            repository.AddCategoryToCategories(category2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(category2.Name, repository.Categories.ToArray()[1].Name);
            Assert.AreEqual(category2.KeyWords, repository.Categories.ToArray()[1].KeyWords);
            Assert.AreEqual(2, repository.Categories.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionExpenseWithEmptyCategory), "")]
        public void AddExpenseNullCategory()
        {
            DateTime month = new DateTime(2020, 1, 24);
            Repository repository = new Repository();
            Expense expense = new Expense { Amount = 23.5, CreationDate = month, Description="cine" };
            repository.AddExpenseToExpenses(expense);
        }

        [TestMethod]
        public void AddExpense()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Category category = new Category { Name = categoryName, KeyWords = keyWords };
            List<Category> categories = new List<Category>();
            categories.Add(category);
            DateTime month = new DateTime(2020, 1, 24);
            Expense expense = new Expense { Amount = 23.5, CreationDate = month, Description = "cine" };
            expense.Category = category;
            Repository repository = new Repository();            
            repository.AddExpenseToExpenses(expense);
            Assert.AreEqual(expense, repository.Expenses.ToArray()[0]);
        }

        [TestMethod]
        public void FindCategoryByName()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>();
            keyWords1.Add("cine");
            keyWords1.Add("teatro");
            keyWords1.Add("casino");
            Category category1 = new Category { Name = "entretenimineto", KeyWords = keyWords1 };
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurante");
            keyWords2.Add("McDonalds");
            keyWords2.Add("cena");
            Category category2 = new Category { Name = "comida", KeyWords = keyWords2 };
            categoryList.Add(category1);
            categoryList.Add(category2);
            Repository respoitory = new Repository(categoryList);
            Category category3 = respoitory.FindCategoryByName("entretenimiento");
            Assert.AreEqual(category1, category3);
        }

        [TestMethod]
        public void FindCategoryByName2()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>();
            keyWords1.Add("cine");
            keyWords1.Add("teatro");
            keyWords1.Add("casino");
            Category category1 = new Category { Name = "diversion", KeyWords = keyWords1};
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurante");
            keyWords2.Add("McDonalds");
            keyWords2.Add("cena");
            Category category2 = new Category { Name = "comida", KeyWords = keyWords2};
            categoryList.Add(category1);
            categoryList.Add(category2);
            Repository repo = new Repository(categoryList);
            Category category3 = repo.FindCategoryByName("entretenimiento");
            Assert.IsNull(category3);
        }

        [TestMethod]
        public void AddValidBudgetToRepository()
        {
            Budget validBudget = new Budget(DateTime.Now.Month, DateTime.Now.Year, 4000);
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
            BudgetCategory validBudgetCategory = new BudgetCategory(categoryFood, 1000);
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
        public void GetAllMonthsString()
        {
            string[] expectedMonthStrings = new string[]
            {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Setiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };
            string[] allMonths = repo.GetAllMonthsString();
            CollectionAssert.AreEqual(expectedMonthStrings, allMonths);
        }

        [TestMethod]
        public void GetAllCategoryNamesValidFormat()
        {
            string[] ExpectedCategoryNames = new string[]
            {
                categoryEntertainment.ToString(),
                categoryFood.ToString(),
            };
            string[] RealCategoryNames = repo.GetAllCategoryStrings();
            CollectionAssert.AreEqual(ExpectedCategoryNames, RealCategoryNames);
        }

        [TestMethod]
        public void BudgetGetOrCreateFindCase()
        {
            string expectedString = "mes: 1 anio: 2020 total: 0";
            string month = "Enero";
            int year = 2020;
            Budget budget = repo.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedString, budget.ToString());
        }

        [TestMethod]
        public void BudgetGetOrCreateCreateCase()
        {
            string month = "Diciembre";
            int year = 2020;
            Budget expectedBudget = new Budget(12, 2020, 0, repo.Categories);

            Budget budget = repo.BudgetGetOrCreate(month, year);
            Assert.AreEqual(expectedBudget, budget);
        }

        [TestMethod]
        public void BudgetGetOrCreateAddAndFind()
        {
            Repository emptyRepository = new Repository();
            int month = 12;
            int year = 2020;
            Budget budget = new Budget(month, year, 0);
            emptyRepository.AddBudget(budget);

            Budget actualBudget = emptyRepository.BudgetGetOrCreate("Diciembre", year);
            Assert.AreEqual(budget, actualBudget);
        }

        [TestMethod]
        public void BudgetGetOrCreateCheckCategories()
        {
            List<BudgetCategory> budgetCategories = new List<BudgetCategory>() {
                new BudgetCategory(categoryEntertainment, 0),
                new BudgetCategory(categoryFood, 0),
            };

            Budget actualBudget = repo.BudgetGetOrCreate("Enero", 2020);

            List<BudgetCategory> actualBudgetCategories = actualBudget.BudgetCategories;
            CollectionAssert.AreEqual(budgetCategories, actualBudgetCategories);
        }
    }
}