using System;

namespace BusinessLogic
{
    public class Budget
    {
        public double totalAmount { get => totalAmount; set => SetTotalAmount(value);  }
        public int currentMonth { get; set; }

        public void SetTotalAmount(double vTotalAmount)
        {
            if (totalAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            totalAmount = vTotalAmount;
        }


        public Budget(int vCurrentMonth, double vtotalAmount)
        {
            currentMonth = vCurrentMonth;
            totalAmount = vtotalAmount;
        }


    }
}