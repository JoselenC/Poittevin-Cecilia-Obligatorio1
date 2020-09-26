namespace BusinessLogic
{
    public class BudgetCategory
    {
        public BudgetCategory(Category vCategory, double vAmount)
        {
            category = vCategory;
            amount = vAmount;
        }

        public Category category { get; }
        public double amount { get; }
    }
}