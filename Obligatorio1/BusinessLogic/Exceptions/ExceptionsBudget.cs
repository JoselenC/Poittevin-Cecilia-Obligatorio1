using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class ExceptionBudgetWithEmptyCategory : Exception
    {
        public ExceptionBudgetWithEmptyCategory() :
          base("The budget cannot have an empty category")
        { }
    }

    public class NegativeValueErrorAttribute : Exception
    {
        public NegativeValueErrorAttribute() :
             base("The amount of the budget cannot be negative")
        { }
    }

    public class NoFindBudgetCategory : Exception
    {
        public NoFindBudgetCategory() :
             base("No find budget category")
        { }
    }

    public class NoFindBudget : Exception
    {
        public NoFindBudget() :
             base("No find budget by date")
        { }
    }
}
