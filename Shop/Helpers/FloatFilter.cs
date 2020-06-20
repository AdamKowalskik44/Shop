using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Data.CustomFieldTypes;

namespace Shop.Helpers
{
    public class FloatFilter : Filter
    {
        public FloatFilter(CustomField CustomField) : base(CustomField)
        {
            
        }
        public float MaxAvalibleFloatValue { get; set; }
        public float MinAvalibleFloatValue { get; set; }
        public float MaxFloatValue { get; set; }
        public float MinFloatValue { get; set; }
    }
}
