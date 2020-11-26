using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAcess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataAcess.DBObjects;
using DataAccess;

namespace DataAcess.Mappers.Tests
{
    [TestClass()]
    public class BudgetMapperTest
    {

        public static DataBaseRepository<Category, CategoryDto> Categories;
        public static DataBaseRepository<Budget, BudgetDto> Budgets;
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static List<Category> AllCategories;
        private static Budget JanuaryBudget;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            Budgets = new DataBaseRepository<Budget, BudgetDto>(new BudgetMapper());
            CleanAllData();
            List<string> keyWordsEntertainment = new List<string>
            {
                "movie theater",
                "theater",
                "casino"
            };
            List<string> keyWordsHouse = new List<string>
            {
                "CoffeMaker",
                "toilet paper",
            };
            List<string> keyWordsFood = new List<string>
            {
                "restaurant",
                "McDonalds",
                "Dinner"
            };
            categoryEntertainment = new Category()
            {
                Name = "entertainment",
                KeyWords = keyWordsEntertainment
            };
            categoryFood = new Category()
            {
                Name = "food",
                KeyWords = keyWordsFood
            };
            categoryHouse = new Category()
            {
                Name = "House",
                KeyWords = keyWordsHouse
            };
            AllCategories = new List<Category>()
            {
                categoryHouse,
                categoryFood,
                categoryEntertainment
            };

            JanuaryBudget = new Budget(Months.January)
            {
                Year = 2020,
                BudgetCategories = new List<BudgetCategory>()
                {
                    new BudgetCategory()
                    {
                        Category = categoryEntertainment,
                        Amount = 1000,
                    },
                    new BudgetCategory()
                    {
                        Category = categoryFood,
                        Amount = 2000,
                    }
                }
            };

            try
            {
                Categories.Add(categoryHouse);
                Categories.Add(categoryFood);
                Categories.Add(categoryEntertainment);
                Budgets.Add(JanuaryBudget);
            }
            catch (ExceptionUnableToSaveData) { };
        }

        private static void CleanAllData()
        {
            foreach (Budget budget in Budgets.Get())
            {
                Budgets.Delete(budget);
            }
            foreach (Category category in Categories.Get())
            {
                Categories.Delete(category);
            }
        }

        [TestMethod()]
        public void DomainToDtoTest()
        {
            Budgets.Delete(JanuaryBudget);
            Budgets.Add(JanuaryBudget);
            Assert.AreEqual(Budgets.Find(x => x.IsSameCreationDate(Months.January, 2020)), JanuaryBudget);
        }

        [TestMethod()]
        public void DtoToDomainTest()
        {
            Assert.AreEqual(Budgets.Find(x => x.IsSameCreationDate(Months.January, 2020)), JanuaryBudget);
        }

        [TestMethod()]
        public void UpdateBudgetCategoryTest()
        {
            double oldValue = JanuaryBudget.BudgetCategories[0].Amount;
            JanuaryBudget.BudgetCategories[0].Amount = 12;
            Budgets.Add(JanuaryBudget);

            Budget actualBudget = Budgets.Find(x => x.IsSameCreationDate(Months.January, 2020));
            Assert.AreEqual(actualBudget, JanuaryBudget);
            JanuaryBudget.BudgetCategories[0].Amount = oldValue;
            Budgets.Add(JanuaryBudget);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateDtoObjectTest()
        {
            Budget UpdatedBudget = new Budget(Months.January)
            {
                Year = 2021,
                BudgetCategories = new List<BudgetCategory>()
                {
                    new BudgetCategory()
                    {
                        Category = categoryEntertainment,
                        Amount = 1002,
                    },
                    new BudgetCategory()
                    {
                        Category = categoryFood,
                        Amount = 2002,
                    }
                }
            };
            Budgets.Update(JanuaryBudget, UpdatedBudget);
        }

    }
}