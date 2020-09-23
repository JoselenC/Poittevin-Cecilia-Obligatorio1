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
            Category emptyCategory = new Category("");
            Assert.AreEqual(emptyCategory.nombre,nombre);

        }
    }
}
