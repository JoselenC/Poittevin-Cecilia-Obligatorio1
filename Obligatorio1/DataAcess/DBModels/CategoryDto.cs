﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DBModels
{
    class CategoryDto
    {
        public int CategoryDtoID { get; set; }
        public string Name { get; set; }
        //public KeyWord KeyWords { get; set; }

        //public bool ExistKeyWordInDscription(string description)
        //{
        //    return KeyWords.DescriptionContainAPartOfText(description);
        //}
    }
}
