using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Product
{
    public class ProductFieldValueInt : ProductFieldValue
    {
        [Required]
        public int Value { get; set; }
    }
}
