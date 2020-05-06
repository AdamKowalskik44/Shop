using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.CustomFieldTypes
{
    public class CustomFieldDTO : CustomField
    {
        public List<DropDownItem> DropDownItems { get; set; }

        public CustomFieldDTO(CustomField customField, List<DropDownItem> dropDownItems)
        {
            CustomFieldId = customField.CustomFieldId;
            CustomFieldName = customField.CustomFieldName;
            CategoryId = customField.CategoryId;
            FieldType = customField.FieldType;
            DropDownItems = dropDownItems;
        }

        public CustomFieldDTO(CustomField customField)
        {
            CustomFieldId = customField.CustomFieldId;
            CustomFieldName = customField.CustomFieldName;
            CategoryId = customField.CategoryId;
            FieldType = customField.FieldType;
            DropDownItems = new List<DropDownItem>();
        }
    }
}
