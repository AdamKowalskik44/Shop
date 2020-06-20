using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Data.CustomFieldTypes;

namespace Shop.Helpers
{
    public class Filter : IFilter
    {
        public Filter(CustomField customField)
        {
            CustomField = customField;
            
        }

        public CustomField CustomField { get; set; }
    }
}
