using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Number { get; set; }

        public string Number2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Postal Code must be 5 characters")]
        public string PostalCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool CurrentAddress { get; set; }
    }
}
