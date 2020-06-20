using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Data.CustomFieldTypes;

namespace Shop.Helpers
{
    public class BoolFilter : Filter
    {
        public BoolFilter(CustomField customField) : base(customField)
        {

        }

        public bool TrueValue { get; set; }
        public bool FalseValue { get; set; }
    }
}
