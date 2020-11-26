namespace DataAcess.DBObjects
{
    public class BudgetCategoryDto
    {
        public int BudgetCategoryDtoID { get; set; }
        public int CategoryDtoID { get; set; }
        public CategoryDto Category { get; set; }

        public double Amount { get; set; }

        public int BudgetDtoID { get; set; }
        public BudgetDto BudgetDto { get; set; }
    }
}