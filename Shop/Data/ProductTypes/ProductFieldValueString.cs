﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.ProductTypes
{
    public class ProductFieldValueString : ProductFieldValue
    {
        [Required]
        public string Value { get; set; }
    }
}
