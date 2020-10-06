using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class repositoryTest
    {


        [TestMethod]
        public void findCategory()
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
            Repository repo = new Repository(categoryList);
            string description = "cuando fuimos al cine";
            Category category3 = repo.FindCategoryByDescription(description);
            Assert.AreEqual(category1, category3);

        }

        [TestMethod]
        public void findCategory2()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>();
            keyWords1.Add("cena");
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
            Repository repo = new Repository(categoryList);
            string description = "cuando fuimos al cine";
            Assert.IsNull(repo.FindCategoryByDescription(description));
        }

        [TestMethod]
        public void findCategory3()
        {
            List<Category> categoryList = new List<Category>();
            List<string> keyWords1 = new List<string>();
            keyWords1.Add("cena");
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
            Repository repo = new Repository(categoryList);
            string description = "cuando fuimos al shopping";
            Assert.IsNull(repo.FindCategoryByDescription(description));

        }

        [TestMethod]
        public void monthsOrdered()
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
        public void monthsOrdered2()
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
        public void monthsOrdered3()
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
            repository.addCategory(categoryName, keyWords);
            repository.addExpense(230, month1, "cine");
            List<string[]> reports1 = repository.ExpenseReport(month1.Month.ToString());
            Assert.AreEqual(reports.ToArray()[0][0], reports1.ToArray()[0][0]);
            Assert.AreEqual(reports.ToArray()[0][1], reports1.ToArray()[0][1]);
            Assert.AreEqual(reports.ToArray()[0][2], reports1.ToArray()[0][2]);
            Assert.AreEqual(reports.ToArray()[0][3], reports1.ToArray()[0][3]);
        }

       

        [TestMethod]
        public void AddCategoryinvalidName()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);            
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);
            repository.addCategory(categoryName, keyWords);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);
            

        }

        [TestMethod]
        public void AddCategoryinvalidName2()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);
            String categoryName2 = "entretenimiento";
            List<string> keyWords2 = new List<string>();
            keyWords.Add("casino");
            keyWords.Add("shopping");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.addCategory(categoryName2, keyWords2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);


        }

        [TestMethod]
        public void AddCategoryvalidName()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            keyWords2.Add("cena");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.addCategory(categoryName2, keyWords2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(category2.Name, repository.Categories.ToArray()[1].Name);
            Assert.AreEqual(category2.KeyWords, repository.Categories.ToArray()[1].KeyWords);
            Assert.AreEqual(2, repository.Categories.Count);
        }

        [TestMethod]
        public void AddCategoryinvalidKeyWords()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);            
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("cine");
            keyWords2.Add("teatro");
            repository.addCategory(categoryName2, keyWords2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);
        }

        [TestMethod]
        public void AddCategoryinvalidKeyWords2()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("teatro");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("Cine");
            keyWords2.Add("Restaurante");
            repository.addCategory(categoryName2, keyWords2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(1, repository.Categories.Count);
        }

        [TestMethod]
        public void AddCategoryValidKeyWords()
        {
            String categoryName = "Entretenimiento";
            List<string> keyWords = new List<string>();
            keyWords.Add("cine");
            keyWords.Add("sala de juego");
            Category category = new Category(categoryName, keyWords);
            Repository repository = new Repository();
            repository.addCategory(categoryName, keyWords);
            String categoryName2 = "Comida";
            List<string> keyWords2 = new List<string>();
            keyWords2.Add("restaurant");
            Category category2 = new Category(categoryName2, keyWords2);
            repository.addCategory(categoryName2, keyWords2);
            Assert.AreEqual(category.Name, repository.Categories.ToArray()[0].Name);
            Assert.AreEqual(category.KeyWords, repository.Categories.ToArray()[0].KeyWords);
            Assert.AreEqual(category2.Name, repository.Categories.ToArray()[1].Name);
            Assert.AreEqual(category2.KeyWords, repository.Categories.ToArray()[1].KeyWords);
            Assert.AreEqual(2, repository.Categories.Count);
        }       
}