using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category
    {
        public string nombre{ get; set; }

        public Category(string nombreReceived)
        {
            this.nombre = nombreReceived;
        }

    }
}
