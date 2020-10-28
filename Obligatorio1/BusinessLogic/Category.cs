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

        private KeyWord keyWords;

        public string Name {get=>name; set=>SetName(value); }

        public KeyWord KeyWords { get=>keyWords; set=>SetKeyWords(value); } 

        private void SetName(string vName)
        {
             if (vName.Length > 15 || vName.Length < 3)  
                throw new ExcepcionInvalidNameLengthCategory();
            if (vName.All(char.IsDigit))
                throw new ExcepcionInvalidNameDigitCategory();
            name = vName;
        }

        private void SetKeyWords(KeyWord vKeyWords)
        {
            keyWords = vKeyWords;
        }

        public override bool Equals(object obj)
        {
            if (obj is Category category)
            {
                bool isEqualName = Name == category.Name;
                bool isEqualKeyWords = keyWords.Equals(category.keyWords);
                return isEqualName && isEqualKeyWords;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool ExistThisKey(string pKeyWord)
        {
            return KeyWords.ExistThisKey(pKeyWord);
        }

        public bool ExistKeyWordInAnotherCategory(KeyWord pKeyWords)
        {
            return KeyWords.ExistKeyWords(pKeyWords); 
        }

        public bool ExistKeyWordInDscription(string description)
        {
           return KeyWords.DescriptionContainAPartOfDescription(description);
        }

        public bool IsSameCategoryName(string categoryName)
        {
            return Name == categoryName;
        }

        public bool IsKeyWordInDescription(string[] descriptionArray)
        {
            bool exist = false;
            foreach (string description in descriptionArray)
            {
                exist = ExistKeyWordInDscription(description);
                if (exist == true)
                    return true;
            }
            return exist;
        }

      
    }
}