namespace DataAcess.DBObjects
{
    class BudgetCategoryDto
    {
        public int BudgetCategoryDtoID { get; set; }
        public CategoryDto Category { get; set; }

        public double Amount { get; set; }
    }
}