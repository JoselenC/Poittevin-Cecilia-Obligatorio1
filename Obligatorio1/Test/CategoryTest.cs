using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void createCategoryEmptyName()
        {
            String nombre = "";
            Category emptyCategory = new Category(nombre);
            Assert.AreEqual(emptyCategory.nombre,nombre);

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
