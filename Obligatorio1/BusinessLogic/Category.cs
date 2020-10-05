using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category
    {
        public string Name { get; set; }

        public List<string> KeyWords { get; set; }

        private bool ValidName(string nameReceived)
        {
            if (nameReceived.All(char.IsDigit) || nameReceived.Length > 15 || nameReceived.Length < 3) { return false; }
            return true;

        }

        private bool ValidKeyWords(List<string> keyWordsReceived)
        {
            if (keyWordsReceived.Count > 10) { return false; }
            return true;

        }

        public Category(string nameReceived, List<string> keyWordsReceived)
        {
            if (!ValidName(nameReceived) || !ValidKeyWords(keyWordsReceived))
            {
                throw new InvalidOperationException();
            }
            this.Name = nameReceived;
            this.KeyWords = keyWordsReceived;
        }

    }
}