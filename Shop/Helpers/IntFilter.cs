using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Data.CustomFieldTypes;

namespace Shop.Helpers
{
    public class IntFilter : Filter
    {
        public IntFilter(CustomField customField) : base(customField)
        {
            
        }

        public int MaxAvalibleIntValue { get; set; }
        public int MinAvalibleIntValue { get; set; }
        public int MaxIntValue { get; set; }
        public int MinIntValue { get; set; }
    }
}
