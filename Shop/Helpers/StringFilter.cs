using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Data.CustomFieldTypes;

namespace Shop.Helpers
{
    public class StringFilter : Filter
    {
        public StringFilter(CustomField customField, string firstValue) : base(customField)
        {
            AvalibleValues = new List<string>();
            FilteredValues = new List<string>();
            AddAvalibleValue(firstValue);
        }

        //todo encapsulate
        public List<string> AvalibleValues { get; set; }
        public List<string> FilteredValues { get; set; }

        public void AddAvalibleValue(string newValue)
        {
            foreach (var value in AvalibleValues)
            {
                if (value == newValue)
                {
                    return;
                }
            }
            AvalibleValues.Add(newValue);
        }
    }
}
