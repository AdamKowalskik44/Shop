using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.ProductTypes
{
    public class ProductFieldValueDDI : ProductFieldValue
    {
        public string Value { get; set; }

        //public int DropDownItemId { get; set; }
        //[ForeignKey("DropDownItemId")]
        //public virtual DropDownItem DropDownItem { get; set; }
    }
}
