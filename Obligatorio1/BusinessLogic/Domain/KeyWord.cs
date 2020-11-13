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
            if (vKeyWord != "" && vKeyWord.Length < 10)
                value = vKeyWord;

            else if (vKeyWord.Length >= 10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
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
            if(vKeyWords.Length>10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();
            value = vKeyWords;
        }

        public KeyWord()
        {
        }    

    }
}
