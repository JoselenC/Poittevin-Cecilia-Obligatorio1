using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BusinessLogic
{
    public class Category
    {

        private string name;
        private List<String> keyWords;

        public string Name {get=>name; set=>SetName(value); }
        public List<string> KeyWords { get=>keyWords; set=>SetKeyWords(value); } 

        private void SetName(string vName)
        {
             if (vName.Length > 15 || vName.Length < 3)  
                throw new ExcepcionInvalidNameLengthCategory();
            if (vName.All(char.IsDigit))
                throw new ExcepcionInvalidNameDigitCategory();
            name = vName;

        }

        private void SetKeyWords(List<string> vKeyWords)
        {
            if (vKeyWords.Count > 10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
            keyWords = vKeyWords;
        }      

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Category category)
            {
                bool isEqualName = Name == category.Name;
                bool isEqualKeyWords = KeyWords.OrderBy(t => t).SequenceEqual(category.KeyWords.OrderBy(t => t));
                return isEqualName && isEqualKeyWords;
            }
            return false;
        }
    }
}