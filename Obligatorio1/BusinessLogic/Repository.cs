using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Repository
    {
        public List<Category> categoryList { get; set; }

       // public List<Expense> expenseList { get; set; }

        public Repository()
        {
            this.categoryList = new List<Category>();
            
        }


        public Category findCategory(string description, List<Category> categoryListReceived)
        {
            Category category = null;
            string[] desc = description.Split(' ');
            bool exist = false;
            int cont = 0;
            for (int i = 0; i < categoryListReceived.Count; i++)
            {
                exist = false;
                for (int j = 0; j < desc.Length && !exist; j++)
                {
                    exist = categoryListReceived[i].keyWords.Contains(desc[j]);
                }
                if (exist)
                {
                    category = categoryListReceived[i];
                    cont=cont+1;
                }
            }
            if (cont == 1)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

       

    }
}
