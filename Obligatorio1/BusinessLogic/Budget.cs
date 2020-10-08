using System;

namespace BusinessLogic
{
    public class Budget
    {

        private double totalAmount;
        private readonly int month;
        private int year;

        public double TotalAmount { get => totalAmount; set => SetTotalAmount(value); }
        public int Month { get => month ; }
        public int Year { get => year; set => SetYear(value); }

        private void SetTotalAmount(double vTotalAmount)
        {
            if (vTotalAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            totalAmount = vTotalAmount;
        }

        private void SetYear(int vYear)
        {
            if (vYear > 2030 || vYear < 2018 )
            {
                throw new ArgumentOutOfRangeException();
            }
            year = vYear;
        }
        private bool ValidMonth(int vMonth)
        {
            if (vMonth > 12 || vMonth < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            return true;
        }

        public Budget(int vCurrentMonth, int vCurrentYear, double vtotalAmount)
        {
            if (ValidMonth(vCurrentMonth))
            {
                month = vCurrentMonth;
                TotalAmount = vtotalAmount;
                Year = vCurrentYear;
            }
        }

    }
}