using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required]
        public string SenderInfo { get; set; }
        
        [Required]
        public string SenderAccountNumber { get; set; }

        [Required]
        public string SenderBankInfo { get; set; }

        [Required]
        public string TransferTitle { get; set; }

        [Required]
        public float TransferValue { get; set; }

        [Required]
        public DateTime TransferDate { get; set; }

        [Required]
        public DateTime TransferReceivedDate { get; set; }

        [Required]
        public string BankOperationNumber { get; set; }
    }
}
