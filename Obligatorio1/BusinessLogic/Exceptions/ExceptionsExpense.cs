using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class ExcepcionInvalidYearExpense : Exception
    {
        public ExcepcionInvalidYearExpense() :
        base("Invalid year expense")
        { }
    }

    public class ExcepcionNegativeAmountExpense : Exception
    {
        public ExcepcionNegativeAmountExpense() :
        base("Invalid negative amount of the expense")
        { }
    }

    public class ExcepcionInvalidAmountExpense : Exception
    {
        public ExcepcionInvalidAmountExpense() :
        base("Invalid amount of the expense")
        { }
    }

    public class ExcepcionInvalidDescriptionLengthExpense : Exception
    {
        public ExcepcionInvalidDescriptionLengthExpense() :
        base("Invalid length of the expense description")
        { }
    }

    public class ExcepcionExpenseWithEmptyCategory : Exception
    {
        public ExcepcionExpenseWithEmptyCategory() :
        base("The expense cannot have an empty category")
        { }
    }

    public class NoFindEqualsExpense : Exception
    {
        public NoFindEqualsExpense() :
        base("No find equals expense")
        { }
    }

    public class NoFindExpenseByDate : Exception
    {
        public NoFindExpenseByDate() :
        base("No find expense by date")
        { }
    }

    public class NoAsignCategoryByDescriptionExpense : Exception
    {
        public NoAsignCategoryByDescriptionExpense() :
           base("No find category in description of the expense")
        { }
    }
}
