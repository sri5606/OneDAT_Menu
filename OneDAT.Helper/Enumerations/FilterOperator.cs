using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Helper.Enumerations
{
    public enum FilterOperator
    {
        Equal = 0,
        NotEqual = 1,
        LessThanOrEqual = 2,
        LessThan = 3,
        GreaterThanOrEqual = 4,
        GreaterThan = 5,
        IsNotNull = 6,
        IsNull = 7,
        Contains = 8,
        NotContains = 9,
        BeginsWith = 10,
        In = 11,
        Between = 12,
        Or=13
    }
}
