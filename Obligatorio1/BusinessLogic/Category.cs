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

        private bool validName(string nameReceived)
        {
            if (nameReceived == "" || nameReceived.All(char.IsDigit)) { return false; }
            if (nameReceived.Length>15) { return false; }
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

    }
}
