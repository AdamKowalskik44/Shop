using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Range(0, 999999999, ErrorMessage = "Number is invalid")]
        public string Number { get; set; }

        [Range(0, 999999999, ErrorMessage = "Number is invalid")]
        public string Number2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Range(0, 99999, ErrorMessage = "Postal code is invalid")]
        public string PostalCode { get; set; }

        [Required]
        [Range(100000000, 999999999,
        ErrorMessage = "Number must be 9 digits.")]
        public string PhoneNumber { get; set; }

        public bool CurrentAddress { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
