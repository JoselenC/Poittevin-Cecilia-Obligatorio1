using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBObjects
{
    public class KeyWordsDto
    {
        public int KeyWordsDtoID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Value { get; set; }

        public int CategoryDtoID { get; set; }
        public CategoryDto CategoryDto { get; set; }

        public override bool Equals(object obj)
        {
            return obj is KeyWordsDto dto &&
                   Value == dto.Value;
        }
    }
}
