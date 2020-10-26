using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class KeyWord
    {
        private List<string> keyWords;

    
        public KeyWord(List<string> vKeyWords)
        {
            if(vKeyWords.Count>10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
            keyWords = vKeyWords;


        }

        public KeyWord()
        {
            keyWords = new List<string>();
        }

        public void SetKeyWord(KeyWord vKeyWord)
        {
            if (vKeyWord.keyWords.Count > 10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
            keyWords = vKeyWord.keyWords;
        }

        public override bool Equals(object obj)
        {
            if (obj is KeyWord key)
            {
                return keyWords.OrderBy(t => t).SequenceEqual(key.keyWords.OrderBy(t => t));
            }
            return false;
        }

        public bool KeywordContainsAPartOfDescription(string description) {
            return keyWords.Contains(description);
        }

        private bool ExistKeyWord(List<string> pKeyWords, ref bool exist, string vKeyWord)
        {           
            foreach (string keyWords in pKeyWords)
            {
                if (vKeyWord.ToLower() == keyWords.ToLower())
                    exist = false;
            }
            return exist;
        }

        public bool ExistKeyWordInAnotherCategory(KeyWord pKeyWords, ref bool exist,Category category)
        {
            foreach (string vKeyWord in category.KeyWords.keyWords)
            {
                exist= ExistKeyWord(pKeyWords.keyWords, ref exist, vKeyWord);
            }
            return exist;
        }

        public bool ExistThisKey(string pKeyWord)
        {
            return keyWords.Contains(pKeyWord.ToLower());
        }

        public List<string> AsignKeyWordToList(KeyWord keyWordsCategory)
        {
            List<string> vKwyWords = new List<string>();
            vKwyWords = keyWordsCategory.keyWords;
            return vKwyWords;
        }

        public void AddKeyWord(string vKeyWord)
        {
            if (vKeyWord != "" && !keyWords.Contains(vKeyWord.ToLower()) && !keyWords.Contains(vKeyWord.ToUpper()) && keyWords.Count<10)
                keyWords.Add(vKeyWord);
            else if (keyWords.Contains(vKeyWord.ToLower()) || keyWords.Contains(vKeyWord.ToUpper()))
                throw new ExcepcionInvalidRepeatedKeyWordsCategory();
            else if(keyWords.Count>=10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
            else
                throw new InvalidKeyWord();
        }

        public void DeleteKeyWord(string vKeyWord)
        {
            keyWords.Remove(vKeyWord);
        }

    }
}
