using OneDAT.Helper.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Helper.Models
{
   public sealed class FilterCondition
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public FilterOperator Operator { get; private set; }
        public FilterCondition(string key, FilterOperator @operator ,string value )
        {
            Key = key;
            Operator = @operator;
            Value = value;
        }
    }
}
