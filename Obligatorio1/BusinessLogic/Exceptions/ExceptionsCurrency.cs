using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ExceptionInvalidQuotation : Exception
    {
        public ExceptionInvalidQuotation() :
        base("The quotation of the currency cannot have more than two decimal places")
        { }
    }

    public class ExceptionNegativeQuotation : Exception
    {
        public ExceptionNegativeQuotation() :
        base("The quotation of the currency must be positive")
        { }
    }

    public class ExceptionInvalidLengthSymbol : Exception
    {
        public ExceptionInvalidLengthSymbol() :
        base("The symbol must be between 3 and 20 characters long.")
        { }
    }

    public class ExceptionInvalidLengthCurrencyName : Exception
    {
        public ExceptionInvalidLengthCurrencyName() :
        base("The name must be between 3 and 20 characters long.")
        { }
    }

    public class ExceptionAlreadyExistTheCurrencyName : Exception
    {
        public ExceptionAlreadyExistTheCurrencyName() :
        base("Already exist the currency name")
        { }
    }

    public class ExceptionAlreadyExistTheCurrencySymbol : Exception
    {
        public ExceptionAlreadyExistTheCurrencySymbol() :
       base("Already exist the currency symbol")
        { }
    }

    public class NoFindCurrency : Exception
    {
        public NoFindCurrency() :
        base("no find currency")
        { }
    }

    public class NoFindCurrencyByName : Exception
    {
        public NoFindCurrencyByName() :
        base("No find currency by name")
        { }
    }

    public class ExcepcionNoDeleteCurrency : Exception
    {
        public ExcepcionNoDeleteCurrency() :
        base("No delete currency")
        { }
    }
}
