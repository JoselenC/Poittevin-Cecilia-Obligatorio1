using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataAcess.DBObjects;
using DataAcess.Mappers;

namespace DataAccess.Tests
{
    [TestClass()]
    public class DataBaseRepositoryTest
    {
        public static DataBaseRepository<Category, CategoryDto> Categories;
        private static Category categoryEntertainment;
        private static Category categoryFood;
        private static Category categoryHouse;
        private static List<Category> AllCategories;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        { 
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
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
            try
            {
                Categories.Add(categoryHouse);
                Categories.Add(categoryFood);
                Categories.Add(categoryEntertainment);
            } catch (ExceptionUnableToSaveData) { };
        }

        private static void CleanAllData()
        {
            foreach (Category category in Categories.Get())
            {
                Categories.Delete(category);
            }
        }

        [TestMethod()]
        public void AddSuccessCaseTest()
        {
            Category categoryTest = new Category()
            {
                Name = "Testing",
            };
            Categories.Add(categoryTest);
            Categories.Delete(categoryTest);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void DeleteTest()
        {
            Category testCategory = new Category()
            {
                Name = "Test"
            };
            Categories.Delete(testCategory);

            Category realCategory = Categories.Find(x => x.Name == testCategory.Name);
        }

        [TestMethod()]
        public void FindTest()
        {
            Category actualHouseCategory = Categories.Find(x => x.Name == "House");
            Assert.AreEqual(categoryHouse, actualHouseCategory);
        }

        [TestMethod()]
        public void GetTest()
        {
            List<Category> realAllCategories = Categories.Get();
            realAllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            AllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            CollectionAssert.AreEqual(AllCategories, realAllCategories);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void SetTest()
        {
            Categories.Set(AllCategories);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Category categoryHouseUpdated = new Category()
            {
                Name = "HouseUpdated",
            };
            Categories.Update(categoryHouse, categoryHouseUpdated);

            Category realHouseUpdated = Categories.Find(x => x.Name == "HouseUpdated");

            Assert.AreEqual(categoryHouseUpdated, realHouseUpdated);
            Categories.Update(categoryHouseUpdated, categoryHouse);
        }
    }
}