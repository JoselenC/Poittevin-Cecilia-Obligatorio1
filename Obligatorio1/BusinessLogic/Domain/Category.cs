using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Category
    {

        private string name;

        private List<KeyWord> keyWords;

        public string Name {get=>name; set=>SetName(value); }

        public List<string> KeyWords { get=> GetKeyWord(); set=>SetKeyWords(value); }

        public Category()
        {
            keyWords = new List<KeyWord>();
        }

        private List<string> GetKeyWord()
        {
            List<string> returnKeyWords = new List<string>();
            foreach (KeyWord keyWord in keyWords)
            {
                returnKeyWords.Add(keyWord.Value);
            }
            return returnKeyWords;
        }

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
            if (!(vKeyWords is null))
            {
                if (vKeyWords.Count <= 10)
                {
                    foreach (string keyWord in vKeyWords)
                    {
                        KeyWord keyWordToAdd = new KeyWord()
                        {
                            Value = keyWord
                        };
                        keyWords.Add(keyWordToAdd);
                    }
                }
                else
                {
                    throw new ExcepcionInvalidKeyWordsLengthCategory();
                }
            }
           
        }

        public override bool Equals(object obj)
        {
            if (obj is Category category)
            {
                bool isEqualName = Name == category.Name;
                bool isEqualKeyWords = keyWords.SequenceEqual(category.keyWords);
                return isEqualName && isEqualKeyWords;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool CategoryContainKeyword(string vKeyWord)
        {
            foreach (KeyWord keyWord in keyWords)
            {
                if (keyWord.Equals(vKeyWord))
                    return true;
            }
            return false;
        }

        public bool IsSameCategoryName(string categoryName)
        {
            return Name.ToLower() == categoryName.ToLower();
        }

        public bool IsKeyWordInDescription(string[] descriptionArray)
        {
            bool exist = false;
            foreach (string description in descriptionArray)
            {
                exist = CategoryContainKeyword(description);
                if (exist == true)
                    return true;
            }
            return exist;
        }

        public int CompareTo(Category compareCategory)
        {
            return Name.CompareTo(compareCategory.Name);
        }

    }
}