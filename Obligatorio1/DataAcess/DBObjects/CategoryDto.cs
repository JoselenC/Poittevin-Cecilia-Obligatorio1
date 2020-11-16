using DataAcess.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    class CategoryDto
    {
        [Key]
        public string Name { get; set; }
        public List<KeyWordsDto> KeyWords { get; set; }
    }
}
