using Shop.Data.CustomFieldTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Product
{
    public class ProductFieldValue : IProductFieldValue
    {
        [Key]
        public int ProductFieldValueId { get; set; }

        public int CustomFieldId { get; set; }

        [ForeignKey("CustomFieldId")]
        public virtual CustomField CustomField { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
