using Shop.Data.CustomFieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;

namespace Shop.Data.ProductTypes
{
    public class ProductDTO
    {
        public Product Product { get; set; }

        public Dictionary<CustomField, ProductFieldValue> Fields { get; set; }

        public List<Photo> Photos { get; set; }

        public Stack<string> CategoryPath { get; set; }

        public ProductDTO()
        {
            Fields = new Dictionary<CustomField, ProductFieldValue>();
            Photos = new List<Photo>();
            CategoryPath = new Stack<string>();
        }
    }
}
