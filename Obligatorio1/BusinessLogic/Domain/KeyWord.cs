using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class KeyWord
    {
        private string value;
        public string Value { get => value; set => SetKeyWord(value);}

        private void SetKeyWord(string vKeyWord)
        {
            if (vKeyWord != "")
                value = vKeyWord; 
            else
                throw new InvalidKeyWord();
        }

        public override bool Equals(object obj)
        {
            bool isKeyWord = obj is KeyWord;
            bool isStringKeyWord = obj is string;
            if (isKeyWord)
            {
                KeyWord word = (KeyWord)obj;
                return value == word.value;
            }
            else if (isStringKeyWord)
            {
                string wordString = (string)obj;
                return value == wordString;
            }
            return false;
        }

        public KeyWord(string vKeyWords)
        {
            if(vKeyWords!="")
            value = vKeyWords;
            else
                throw new InvalidKeyWord();
        }

        public KeyWord()
        {
        }    

    }
}
