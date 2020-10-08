using System;

namespace BusinessLogic
{
    public class BudgetCategory
    {
        private Category category;
        private double amount;
        public Category Category { get => category; set => SetCategory(value) ; }
        public double Amount { get => amount; set => SetAmount(value); }


        private void SetCategory(Category vCategory)
        {
            if (vCategory == null)
            {
                throw new ArgumentNullException();
            }
            category = vCategory;
        }
        private void SetAmount(double vAmount)
        {
            if (vAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            amount = vAmount;
        }

        public BudgetCategory(Category vCategory, double vAmount)
        {
            Category = vCategory;
            Amount = vAmount;
        }

    }
}