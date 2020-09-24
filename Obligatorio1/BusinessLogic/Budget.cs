using System;

namespace BusinessLogic
{
    public class Budget
    {
        public int totalAmount { get => totalAmount; set => SetTotalAmount(value);  }
        public DateTime date { get; set; }

        public void SetTotalAmount(int vTotalAmount)
        {
            if (totalAmount < 0)
            {
                throw new NegativeValueErrorAttribute();
            }
            totalAmount = vTotalAmount;
        }


        public Budget(DateTime currentDate, int vtotalAmount)
        {
            date = currentDate;
            totalAmount = vtotalAmount;
        }


    }
}