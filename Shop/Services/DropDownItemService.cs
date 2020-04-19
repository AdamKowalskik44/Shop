using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class DropDownItemService
    {
        private readonly ApplicationDbContext _db;

        public DropDownItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<DropDownItem> GetDropDownItems(int customFieldId)
        {
            List<DropDownItem> items = _db.DropDownItems.ToList();
            List<DropDownItem> result = new List<DropDownItem>();

            foreach (var item in items)
            {
                if (item.CustomFieldId == customFieldId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public bool CreateDropDownItem(DropDownItem dropDownItem)
        {
            try
            {
                _db.DropDownItems.Add(dropDownItem);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteDropDownItem(DropDownItem dropDownItem)
        {
            if (_db.DropDownItems.Contains(dropDownItem))
            {
                _db.DropDownItems.Remove(dropDownItem);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateDropDownItem(DropDownItem dropDownItem)
        {
            try
            {
                var existingDropDownItem = _db.DropDownItems.FirstOrDefault(u => u.DropDownItemId == dropDownItem.DropDownItemId);
                if (existingDropDownItem != null)
                {
                    existingDropDownItem.DropDownItemName = dropDownItem.DropDownItemName;
                    existingDropDownItem.CustomFieldId = dropDownItem.CustomFieldId;
                    _db.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
