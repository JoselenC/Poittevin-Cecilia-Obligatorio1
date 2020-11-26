using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.DBObjects;
using BusinessLogic;
using DataAcess.Mappers;

namespace DataAcces.Tests
{
    [TestClass()]
    public class DataBaseManagerRepositoryTest
    {

        [TestMethod()]
        public void DataBaseManagerRepositoryCreationCategoriesTypeTest()
        {
            DataBaseManagerRepository dataBaseManagerRepository = new DataBaseManagerRepository();
            Assert.IsInstanceOfType(dataBaseManagerRepository.Categories, typeof(DataBaseRepository<Category, CategoryDto>));
        }

        [TestMethod()]
        public void DataBaseManagerRepositoryCreationExpensesTypeTest()
        {
            DataBaseManagerRepository dataBaseManagerRepository = new DataBaseManagerRepository();
            Assert.IsInstanceOfType(dataBaseManagerRepository.Expenses, typeof(DataBaseRepository<Expense, ExpenseDto>));
        }

        [TestMethod()]
        public void DataBaseManagerRepositoryCreationBudgetsTypeTest()
        {
            DataBaseManagerRepository dataBaseManagerRepository = new DataBaseManagerRepository();
            Assert.IsInstanceOfType(dataBaseManagerRepository.Budgets, typeof(DataBaseRepository<Budget, BudgetDto>));
        }

        [TestMethod()]
        public void DataBaseManagerRepositoryCreationCurrenciesTypeTest()
        {
            DataBaseManagerRepository dataBaseManagerRepository = new DataBaseManagerRepository();
            Assert.IsInstanceOfType(dataBaseManagerRepository.Currencies, typeof(DataBaseRepository<Currency, CurrencyDto>));
        }

        [TestMethod()]
        public void DataBaseManagerRepositoryCreationTwiseToTestInsertErrorHandlerTest()
        {
            new DataBaseManagerRepository();
            new DataBaseManagerRepository();
        }
    }
}