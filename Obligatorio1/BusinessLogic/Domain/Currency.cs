using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Currency
    {
        private string name;

        private string symbol;

        private double quotation;

        public string Name { get=>name; set=>SetName(value); }

        public string Symbol { get=>symbol; set=>SetSymbol(value); }

        public double Quotation { get=>quotation; set=>SetQuotation(value); }

        private void SetName(string vName)
        {
            if (vName.Length < 3 || vName.Length > 20)
                throw new ExceptionInvalidLengthCurrencyName();
            name= vName;
        }

        private void SetSymbol(string vSymbol)
        {
            if (vSymbol.Length < 1 || vSymbol.Length > 3)
                throw new ExceptionInvalidLengthSymbol();
           symbol = vSymbol;
        }

        private void SetQuotation(double vQuotation)
        {
            if (vQuotation <= 0)
                throw new ExceptionNegativeQuotation();
            if (vQuotation != Math.Round(vQuotation, 2))
                throw new ExceptionInvalidQuotation();
            quotation = vQuotation;
        }
        public bool IsSameCurrencyName(string currencyName)
        {
            return Name == currencyName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Currency currency)
            {
                bool boolName = Name == currency.Name;
                bool boolSymbol = Symbol == currency.Symbol;
                bool boolQuotation = Quotation == currency.Quotation;
                return boolName && boolSymbol && boolQuotation;
            }
            return false;
        }
        public override string ToString()
        {
            return name;
        }
       
    }
}
