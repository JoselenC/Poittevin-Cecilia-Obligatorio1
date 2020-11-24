using System;

namespace BusinessLogic
{   
    public class ExcepcionInvalidNameLengthCategory : Exception
    {
        public ExcepcionInvalidNameLengthCategory() :
           base("The name must be between 3 and 15 characters long.")
        { }        
    }

    public class ExcepcionInvalidNameDigitCategory : Exception
    {
        public ExcepcionInvalidNameDigitCategory() :
          base("The name of the category cannot be just a number ")
        { }
    }

    public class ExcepcionInvalidKeyWordsLengthCategory : Exception
    {
        public ExcepcionInvalidKeyWordsLengthCategory() :
         base("Invalid number of keywords")
        { }
    }

    public class ExcepcionInvalidRepeatedNameCategory : Exception
    {
        public ExcepcionInvalidRepeatedNameCategory() :
        base("The category name already exist in de system")
        { }
    }

    public class ExcepcionInvalidRepeatedKeyWordsCategory : Exception
    {
        public ExcepcionInvalidRepeatedKeyWordsCategory() :
        base("The key word already exist in the category")
        { }
    }

    public class ExcepcionInvalidRepeatedKeyWordsInAnotherCategory : Exception
    {
        public ExcepcionInvalidRepeatedKeyWordsInAnotherCategory() :
        base("The key word already exist in the system")
        { }
    }
  
    public class NoFindCategoryByName : Exception
    {
        public NoFindCategoryByName() :
        base("No find category by name")
        { }
    }
    
    public class InvalidKeyWord : Exception
    {
        public InvalidKeyWord() :
        base("Invalidkey word")
        { }
    }

    public class ValueNotFound : Exception
    {
    }

    public class ExceptionUnableToSaveData : Exception
    {
    }

}

