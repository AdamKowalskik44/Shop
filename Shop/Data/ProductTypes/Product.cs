using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProducDescription { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
