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
        public void TestMethod1()
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
            string description = "cuando fuimos al cine";
            for(int n=0; n<categoryList.Count; n++)
            {
                Category category = categoryList[n];
                category.findCategory(description);
            }
        }
    }
}
