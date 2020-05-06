using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.CustomFieldTypes
{
    public class CustomField
    {
        [Key]
        public int CustomFieldId { get; set; }

        [Required]
        public string CustomFieldName { get; set; }

        public int CategoryId 
        { 
            get
            {
                return int.Parse(_categoryId.ToString());
            }
            set
            {
                _categoryId = value;
            }
        }

        private int? _categoryId;

        [ForeignKey("_categoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public CustomFieldType FieldType { get; set; }

        

        //[NotMapped]
        //public List<string> DropDownArgs 
        //{ 
        //    get
        //    {
        //        if (_dropDownArgs == null)
        //        {
        //            return new List<string>();
        //        }
        //        string dropDownArgs = _dropDownArgs;
        //        List<string> args = new List<string>();
        //        string arg = "";
        //        foreach (char item in dropDownArgs)
        //        {
        //            if (item == ';')
        //            {
        //                args.Add(arg);
        //                arg = "";
        //            }
        //            else
        //            {
        //                arg += item;
        //            }
        //        }
        //        return args;
        //    }
        //    set
        //    {
        //        string dropDownArgs = "";
        //        foreach (var item in value)
        //        {
        //            dropDownArgs += item + ";";
        //        }
        //        _dropDownArgs = dropDownArgs;
        //    }
        //}

        //private string _dropDownArgs;
    }
}
