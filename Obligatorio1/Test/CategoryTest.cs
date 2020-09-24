using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryEmptyName()
        {
            String categoryName = "";
            Category emptyCategory = new Category(categoryName);
            

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "")]
        public void createCategoryInvalidName()
        {
            String nombre = "9999";
            Category emptyCategory = new Category(nombre);
        }

        [TestMethod]
        public void createCategory()
        {
            String nombre = "food";
            Category emptyCategory = new Category(nombre);
            Assert.AreEqual(emptyCategory.name, nombre);
        }

        
    }
}
