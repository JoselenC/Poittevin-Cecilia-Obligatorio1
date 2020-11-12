using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Money
    {
        private string name;
        private string symbol;
        private double quotation;

        public string Name { get=>name; set=>setName(value); }

        public string Symbol { get=>symbol; set=>setSymbol(value); }

        public double Quotation { get=>quotation; set=>setQuotation(value); }

        private void setName(string vName)
        {
            if (vName.Length < 3 || vName.Length > 20)
                throw new ExceptionInvalidLengthMoneyName();
            name= vName;
        }

        private void setSymbol(string vSymbol)
        {
            if (vSymbol.Length < 1 || vSymbol.Length > 3)
                throw new ExceptionInvalidLengthSymbol();
           symbol = vSymbol;
        }

        private void setQuotation(double vQuotation)
        {
            if (vQuotation <= 0)
                throw new ExceptionNegativeQuotation();
            if (vQuotation != Math.Round(vQuotation, 2))
                throw new ExceptionInvalidQuotation();
            quotation = vQuotation;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Money money)
            {
                bool boolName = Name == money.Name;
                bool boolSymbol = Symbol == money.Symbol;
                bool boolQuotation = Quotation == money.Quotation;
                return boolName && boolSymbol && boolQuotation;
            }
            return false;
        }

        public bool IsSameMoneyName(string moneyName)
        {
            return Name == moneyName;
        }
    }
}
