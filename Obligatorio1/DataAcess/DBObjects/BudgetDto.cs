using System.Collections.Generic;

namespace DataAcess.DBObjects
{
    internal class BudgetDto
    {
        public int BudgetDtoID { get; set; }
        public int Month { get; set; }
        public double TotalAmount { get; set; }
        public int Year { get; set ; }
        public List<BudgetCategoryDto> BudgetCategories { get; set; }
    }
}