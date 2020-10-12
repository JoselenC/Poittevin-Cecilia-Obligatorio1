using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BusinessLogic
{
    public class Category
    {
        public string Name {get; set; }

        public List<string> KeyWords { get; set; }

        private void ValidName(string nameReceived)
        {
             if (nameReceived.Length > 15 || nameReceived.Length < 3)  
                throw new ExcepcionInvalidNameLengthCategory();
            if (nameReceived.All(char.IsDigit))
                throw new ExcepcionInvalidNameDigitCategory();

        }

        private void ValidKeyWords(List<string> keyWordsReceived)
        {
            if (keyWordsReceived.Count > 10)
                throw new ExcepcionInvalidKeyWordsLengthCategory();

        }   

       

        public Category(string nameReceived, List<string> keyWordsReceived)
        {
            ValidName(nameReceived);
           ValidKeyWords(keyWordsReceived);          
            this.Name = nameReceived;
            this.KeyWords = keyWordsReceived;
        }

    }
}