using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DropDownItem
    {
        [Key]
        public int DropDownItemId { get; set; }

        [Required]
        public string DropDownItemName { get; set; }

        [Required]
        public int CustomFieldId { get; set; }

        [ForeignKey("CustomFieldId")]
        public virtual CustomField CustomField { get; set; }
    }
}
