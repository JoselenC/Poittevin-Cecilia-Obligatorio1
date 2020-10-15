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
            categoryEntertainment = new Category("entretenimiento", keyWords1);
            List<string> keyWords2 = new List<string>
            {
                "restaurante",
                "McDonalds",
                "cena"
            };
            categoryFood = new Category("comida", keyWords2);
            List<string> keyWords3 = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            categoryHouse = new Category("House", keyWords3);
            repo.AddCategory(categoryEntertainment);
            repo.AddCategory(categoryFood);
            repo.AddCategory(categoryHouse);

            List<Category> categories = new List<Category>() {
                categoryEntertainment,
                categoryFood,
            };
            JanuaryBudget = new Budget(1, 2020, 0, categories);
            repo.AddBudget(JanuaryBudget);

            Expense januaryExpenseFood = new Expense(200, new DateTime(2020, 1, 1), "sushi night")
            {
                Category = categoryFood
            };
            Expense januaryExpenseFood2 = new Expense(110.50, new DateTime(2020, 1, 1), "sushi night")
            {
                Category = categoryFood
            };
            Expense januaryExpenseEntertainment = new Expense(230.15, new DateTime(2020, 1, 1), "buy video game")
            {
                Category = categoryEntertainment
            };
            repo.AddExpense(januaryExpenseFood);
            repo.AddExpense(januaryExpenseFood2);
            repo.AddExpense(januaryExpenseEntertainment);
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
            Expense expense1 = new Expense(23, month1, "cine");
            Expense expense2 = new Expense(23, month5, "cine");
            expenses.Add(expense1);
            expenses.Add(expense2);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.MonthsOrdered();
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
            Expense expense1 = new Expense(23, month1, "cine");
            Expense expense2 = new Expense(23, month5, "cine");
            expenses.Add(expense1);
            expenses.Add(expense2);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.MonthsOrdered();
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
            Expense expense1 = new Expense(23, month8, "cine");
            Expense expense2 = new Expense(23, month1, "cine");
            Expense expense3 = new Expense(21, month5, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            List<string> monthsOrder = repo.MonthsOrdered();
            for (int i = 0; i < months.Count; i++)
            {
                Assert.AreEqual(months[i], monthsOrder[i]);
            }
        }

        [TestMethod]
        public void ExpenseByMonths()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 8, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(46, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths2()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 2, 24);
            DateTime month2 = new DateTime(2020, 3, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(0, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths3()
        {
            string month = "Agosto";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths4()
        {
            string month = "Enero";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(21, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths5()
        {
            string month = "Febrero";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 8, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths6()
        {
            string month = "Marzo";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 3, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths7()
        {
            string month = "Abril";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 4, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths8()
        {
            string month = "Mayo";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 5, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths9()
        {
            string month = "Junio";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 6, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths10()
        {
            string month = "Julio";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 7, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths11()
        {
            string month = "Setiembre";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 9, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }


        [TestMethod]
        public void ExpenseByMonths12()
        {
            string month = "Octubre";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 10, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }


        [TestMethod]
        public void ExpenseByMonths13()
        {
            string month = "Noviembre";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 11, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
            Assert.AreEqual(23.5, totalAmount);

        }

        [TestMethod]
        public void ExpenseByMonths14()
        {
            string month = "Diciembre";
            List<Expense> expenses = new List<Expense>();
            DateTime month1 = new DateTime(2020, 12, 24);
            DateTime month2 = new DateTime(2020, 2, 24);
            DateTime month3 = new DateTime(2020, 1, 24);
            Expense expense1 = new Expense(23.5, month1, "cine");
            Expense expense2 = new Expense(23, month2, "cine");
            Expense expense3 = new Expense(21, month3, "casino");
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);
            Repository repo = new Repository();
            repo.Expenses = expenses;
            double totalAmount = repo.ExpenseByMonths(month);
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
            Expense expense = new Expense(230, month1, "cine");            
            Category category = new Category(categoryName, keyWords);
            expense.Category = category;
            repository.AddCategory(category);
            repository.AddExpense(expense);
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
            Category category = new Category(categoryName);
            emptyRepository.AddCategory(category);
            emptyRepository.AddCategory(category);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInvalidRepeatedNameCategory), "")]
        public void AddCategoryAlreadyUsedName()
        {
            string categoryName = "Entretenimiento";
            Category category2 = new Category(categoryName);
            repo.AddCategory(category2);

        }

        [TestMethod]
        public void AddCategoryValidName()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.AddCategory(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            keyWords2.Add("cena");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.AddCategory(category2);
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
            Category category = new Category(categoryName, keyWords);
            repository.AddCategory(category);
            String categoryName2 = "NameExample2";
            List<string> keyWords2 = new List<string>
            {
                "cine",
                "teatro"
            };
            Category category2 = new Category(categoryName2, keyWords2);
            repository.AddCategory(category2);
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
            Category category = new Category(categoryName, keyWords);
            repository.AddCategory(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("Cine");
            keyWords2.Add("Restaurante");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.AddCategory(category2);
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
            Category category = new Category(categoryName, keyWords);
            repository.AddCategory(category);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.AddCategory(category2);
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
            Expense expense = new Expense(23.5, month, "cine");
            repository.AddExpense(expense);
        }

        [TestMethod]
        public void AddExpense()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Category category = new Category(categoryName, keyWords);
            List<Category> categories = new List<Category>();
            categories.Add(category);
            DateTime month = new DateTime(2020, 1, 24);
            Expense expense = new Expense(23.5, month, "cine");
            expense.Category = category;
            Repository repository = new Repository();            
            repository.AddExpense(expense);
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
            Category category1 = new Category("entretenimiento", keyWords1);
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurante");
            keyWords2.Add("McDonalds");
            keyWords2.Add("cena");
            Category category2 = new Category("comida", keyWords2);
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
            Category category1 = new Category("diversion", keyWords1);
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurante");
            keyWords2.Add("McDonalds");
            keyWords2.Add("cena");
            Category category2 = new Category("comida", keyWords2);
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
            Budget expectedBudget = new Budget(1, 2020, 0);
            Budget actualBudget = repo.BudgetGetOrCreate("Enero", 2020);
            Assert.AreEqual(expectedBudget, actualBudget);
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

        [TestMethod]

        public void GetTotalSpentByMonthAndCategoryValidCase()
        {
            double expectedTotalSpentJanuary = 310.50;
            double actualTotalSpentJanuary = repo.GetTotalSpentByMonthAndCategory("Enero", categoryFood);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpenses()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = repo.GetTotalSpentByMonthAndCategory("Marzo", categoryFood);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void GetTotalSpentByMonthAndCategoryMonthWithoutExpensesInCategory()
        {
            double expectedTotalSpentJanuary = 0;
            double actualTotalSpentJanuary = repo.GetTotalSpentByMonthAndCategory("Enero", categoryHouse);

            Assert.AreEqual(expectedTotalSpentJanuary, actualTotalSpentJanuary);
        }

        [TestMethod]
        public void FindBudgetFoundCase()
        {
            Budget actualBudget = repo.FindBudget(1, 2020);
            Assert.AreEqual(JanuaryBudget, actualBudget);
        }


        [TestMethod]
        public void FindBudgetNotFoundCase()
        {
            Budget actualBudget = repo.FindBudget(2, 2020);
            Assert.IsNull(actualBudget);
        }
    }
}