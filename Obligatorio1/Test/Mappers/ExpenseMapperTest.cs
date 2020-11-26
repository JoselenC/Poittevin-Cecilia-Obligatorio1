using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAcess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessLogic;
using DataAcess.DBObjects;

namespace DataAcess.Mappers.Tests
{
    [TestClass()]
    public class ExpenseMapperTest
    {
        public static DataBaseRepository<Expense, ExpenseDto> Expenses;
        public static Expense expenseFood;
        public static Currency currencyDolar;
        public static Category categoryFood;



        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            Expenses = new DataBaseRepository<Expense, ExpenseDto>(new ExpenseMapper());
            List<string> keyWordsFood = new List<string>
            {
                "restaurant",
                "McDonalds",
                "Dinner"
            };
            categoryFood = new Category()
            {
                Name = "food",
                KeyWords = keyWordsFood
            };
            currencyDolar = new Currency()
            {
                Name = "Dolar",
                Symbol = "U$S",
                Quotation = 43
            };
            expenseFood = new Expense()
            {
                Description = "McDonalds",
                Amount = 300,
                CreationDate = new DateTime(2022, 1, 12),
                Currency=currencyDolar,
                Category=categoryFood
            };
            Expenses.Add(expenseFood);
        }

        [TestMethod()]
        public void DomainToDtoTest()
        {
            DateTime creationDate = new DateTime(2022, 1, 1);
            Expense expenseTest = new Expense()
            {
                Description = "McDonalds Test",
                Amount = 110,
                CreationDate = creationDate,
                Currency = currencyDolar,
                Category = categoryFood
            };
            Expenses.Add(expenseTest);
            Expense actualExpense = Expenses.Find(x => (x.CreationDate == creationDate && x.Description == "McDonalds Test"));
            Assert.AreEqual(expenseTest, actualExpense);
            Expenses.Delete(expenseTest);
        }

        [TestMethod()]
        public void DtoToDomainTest()
        {
            Expense actualExpense = Expenses.Find(x => (x.CreationDate == new DateTime(2022, 1, 12) && x.Description == "McDonalds"));
            Assert.AreEqual(expenseFood, actualExpense);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NotFoundExpenseTest()
        {
            Expense actualExpense = Expenses.Find(x => x.Description == "wrong desc");
            Assert.AreEqual(expenseFood, actualExpense);
        }


        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateDtoObjectTest()
        {
            Expenses.Update(expenseFood, expenseFood);
        }
    }
}