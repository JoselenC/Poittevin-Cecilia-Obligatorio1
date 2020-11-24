using System;

namespace BusinessLogic
{
    public class Expense
    {
        private double amount;

        private DateTime creationDate;

        private string description;

        public double Amount{get=>amount; set=>SetAmount(value); }

        public DateTime CreationDate { get=>creationDate; set=>SetdDate(value); }

        public string Description { get=>description; set=>SetDescription(value); }

        public Category Category { get; set;}

        public Currency Currency { get; set; }

        private void SetdDate(DateTime vCreationdate)
        {
            if (vCreationdate.Year > 2030 || vCreationdate.Year < 2018)
                throw new ExcepcionInvalidYearExpense();
            creationDate = vCreationdate;
        }

        private void SetAmount(double vAmount)
        {
            if (vAmount <= 0)
                throw new ExcepcionNegativeAmountExpense();
            if (vAmount!= Math.Round(vAmount, 2))
                throw new ExcepcionInvalidAmountExpense();
            amount = vAmount;
        }

        private void SetDescription(string vDescription)
        {
            if (vDescription.Length < 3 || vDescription.Length > 20)
                throw new ExcepcionInvalidDescriptionLengthExpense();
            description = vDescription;
        }            

        public override bool Equals(object obj)
        {
            if (obj is Expense expense)
            {
                bool equalsAmount = amount == expense.amount;
                bool equalsCreationDate = creationDate == expense.creationDate;
                bool equalsDescription = description == expense.description;
                bool equalsCurrency = Currency.Equals(expense.Currency);
                return equalsAmount && equalsCreationDate && equalsDescription && equalsCurrency;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Description}   {Currency.Symbol}";
        }

        public bool IsExpenseSameMonth(Months month)
        {
            int expected = CreationDate.Month;
            int actual = (int)month;
            return expected == actual;
        }

        public bool IsExpenseSameDate(Months month, int year)
        {
            int expected = CreationDate.Month;
            int actual = (int)month;
            int yearExpected = CreationDate.Year;
            return expected == actual && yearExpected == year;
        }

        public bool IsSameCategory(Category vCategory)
        {
            return Category == vCategory;
        }

        public double ConvertToPesos()
        {
            if (Currency.ToString() == "pesos")
                return amount;
            else
            {
                double quotation = Currency.Quotation;
                return quotation * amount;
            }
        }

        public void IsSameCurrencyExpense(Currency vCurrency)
        {
            if (Currency.Equals(vCurrency))
                throw new ExcepcionNoDeleteCurrency();
        }

        public void EditCurrency(Currency oldCurrency, Currency newCurrency)
        {
            if (Currency.Equals(oldCurrency))
            {
                Currency.Name = newCurrency.Name;
                Currency.Quotation = newCurrency.Quotation;
                Currency.Symbol = newCurrency.Symbol;
            }                  
        }
    }
}