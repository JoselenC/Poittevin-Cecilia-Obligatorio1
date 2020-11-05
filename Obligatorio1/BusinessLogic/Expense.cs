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

        public Money Money { get; set; }

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
                bool equalsMoney = Money == expense.Money;
                return equalsAmount && equalsCreationDate && equalsDescription && equalsMoney;
            }
            return false;
        }


        public override string ToString()
        {
            return $"{Description}   {Money.Symbol}";
        }

        public bool IsExpenseSameMonth(Months month)
        {
            int expected = CreationDate.Month;
            int actual = (int)month;
            return expected == actual;
        }

        public bool IsSameCategory(Category vCategory)
        {
            return Category == vCategory;
        }

        public double ConvertToPesos()
        {
            if (Money.ToString() == "pesos")
                return amount;
            else
            {
                double quotation = Money.Quotation;
                return quotation * amount;
            }
        }

        public void HaveMoney(Money vMoney)
        {
            if (Money.Equals(vMoney))
                throw new ExcepcionNoDeleteMoney();
        }

        public void EditMoney(Money oldMoney, Money newMoney)
        {
            if (Money.Equals(oldMoney))
            {
                Money.Name = newMoney.Name;
                Money.Quotation = newMoney.Quotation;
                Money.Symbol = newMoney.Symbol;
            }                  
        }
    }
}