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
            keyWords = vKeyWords;
        }

        public KeyWord()
        {
            keyWords = new List<string>();
        }

        public void SetKeyWord(KeyWord vKeyWord)
        {
            if (vKeyWord.keyWords.Count >= 10)
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

        public bool Contiene(string description) {
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

        public bool ExistThisKey(string pKeyWord, ref bool exist, Category category)
        {
            if (category.KeyWords.keyWords.Contains(pKeyWord.ToLower()))
                exist = true;
            return exist;
        }

        public List<string> AsignKeyWordToList(KeyWord keyWordsCategory)
        {
            List<string> vKwyWords = new List<string>();
            vKwyWords = keyWordsCategory.keyWords;
            return vKwyWords;
        }

       
    }
}
