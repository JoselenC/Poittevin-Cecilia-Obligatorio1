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
            return obj is KeyWord word &&
                   value == word.value;
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
