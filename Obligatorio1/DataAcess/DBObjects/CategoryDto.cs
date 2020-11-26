using DataAcess.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    public class CategoryDto
    {
        public int CategoryDtoID { get; set; }
        
        [StringLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public List<KeyWordsDto> KeyWords { get; set; }
    }
}
