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
            Repository repo = new Repository();
            string description = "cuando fuimos al cine";
            Category category3 = repo.findCategory(description, categoryList);
            Assert.AreEqual(category1,category3);
             
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
            Repository repo = new Repository();
            string description = "cuando fuimos a la cena";
            Assert.IsNull(repo.findCategory(description, categoryList));
            Category category2 = new Category("comida", keyWords2);
            categoryList.Add(category1);
            categoryList.Add(category2);
            Repository repo = new Repository(categoryList);
            Assert.AreEqual(category1, repo.findCategory(description));
             
        }
    }
}