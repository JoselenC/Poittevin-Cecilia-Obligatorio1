﻿using System;

namespace BusinessLogic
{
    public class BudgetCategory
    {
        public Category category { get => category; set => SetCategory(value); }

        private void SetCategory(Category vCategory)
        {
            category = vCategory ?? throw new ArgumentNullException();
        }

        public double amount { get; }
        public BudgetCategory(Category vCategory, double vAmount)
        {
            category = vCategory;
            amount = vAmount;
        }

    }
}