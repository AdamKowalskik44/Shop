﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.ProductTypes
{
    public class ProductFieldValueBool : ProductFieldValue
    {
        [Required]
        public bool Value { get; set; }
    }
}
