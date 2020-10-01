using System;

namespace BusinessLogic
{
    public class Budget
    {

        public double TotalAmount { get => TotalAmount; set => SetTotalAmount(value);  }
        public int CurrentMonth { get; set; }
        public int CurrentYear { get; set; }


        public void SetTotalAmount(double vTotalAmount)
        {
            if (TotalAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            TotalAmount = vTotalAmount;
            Console.WriteLine("total asignado");
        }


        public Budget(int vCurrentMonth, double vtotalAmount, int vCurrentYear)
        {
            CurrentMonth = vCurrentMonth;
            TotalAmount = vtotalAmount;
            CurrentYear = vCurrentYear;
        }

    }
}