using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.ProductTypes
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public bool MainPhoto { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
