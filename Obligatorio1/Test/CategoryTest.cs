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
            String nombre = "";
            Category emptyCategory = new Category(nombre);
            

        }

        [TestMethod]
        public void createCategory()
        {
            String nombre = "food";
            Category emptyCategory = new Category(nombre);
            Assert.AreEqual(emptyCategory.nombre, nombre);
        }

        
    }
}
