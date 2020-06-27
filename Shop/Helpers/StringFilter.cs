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
            AvalibleValues = new Dictionary<string, bool>();
            AddAvalibleValue(firstValue);
        }

        //todo encapsulate
        public Dictionary<string, bool> AvalibleValues { get; set; }

        public void AddAvalibleValue(string newValue)
        {
            foreach (var value in AvalibleValues)
            {
                if (value.Key == newValue || newValue == string.Empty)
                {
                    return;
                }
            }
            if (newValue != string.Empty)
            {
                AvalibleValues.Add(newValue, false);
            }
        }
    }
}
