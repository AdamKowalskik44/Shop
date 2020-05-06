using Shop.Data.CustomFieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Product;

namespace Shop.Data.Product
{
    public class ProductDTO
    {
        public Product Product { get; set; }

        public Dictionary<CustomField, ProductFieldValue> Fields { get; set; }

        public Stack<string> CategoryPath { get; set; }

        public ProductDTO()
        {
            Fields = new Dictionary<CustomField, ProductFieldValue>();
            CategoryPath = new Stack<string>();
        }
    }
}
