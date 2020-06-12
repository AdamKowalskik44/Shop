using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Order
    {
        [Key]
        public int OrderId {get; set;}

        [Required]
        public float TotalAmount { get; set; }

        [Required]
        public float AmountPaid { get; set; }

        [Required]
        public bool isPaid { get; set; }

        [Required]
        public string ProductListHTML { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
