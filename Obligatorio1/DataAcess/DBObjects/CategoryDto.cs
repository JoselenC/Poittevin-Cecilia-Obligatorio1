using DataAcess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    class CategoryDto
    {
        public string Name { get; set; }
        public List<KeyWordsDto> KeyWords { get; set; }
    }
}
