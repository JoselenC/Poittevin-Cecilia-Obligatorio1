using System;

namespace BusinessLogic
{
    public class Budget
    {
        public int totalAmount { get; set; }
        public DateTime date { get; set; }

        public Budget(DateTime currentDate, int vtotalAmount)
        {
            date = currentDate;
            totalAmount = vtotalAmount;
        }


    }
}