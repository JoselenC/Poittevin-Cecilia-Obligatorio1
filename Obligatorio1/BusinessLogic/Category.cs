using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category
    {
        public string name{ get; set; }
        public List<string> keyWords { get; set; }

        private bool validName(string nameReceived)
        {
            if (nameReceived.All(char.IsDigit)) { return false; }
            if (nameReceived.Length>15 || nameReceived.Length<3) { return false; }
            return true;

        }

        private bool validKeyWords(List<string> keyWordsReceived)
        {
            if(keyWordsReceived.Count>10) { return false; }
            return true;

        }

        public Category(string nameReceived)
        {
            if (!validName(nameReceived))
            {
                throw new InvalidOperationException();
            }
            this.name = nameReceived;
        }

        public Category(string nameReceived, List<string> keyWordsReceived)
        {
            if (!validName(nameReceived) || !validKeyWords(keyWordsReceived))
            {
                throw new InvalidOperationException();
            }
            this.name = nameReceived;
        }

    }
}
