using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class AddressService
    {
        private readonly ApplicationDbContext _db;

        public AddressService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAddress(Address address)
        {
            try
            {
                _db.Addresses.Add(address);
                _db.SaveChanges();

                if (address.CurrentAddress)
                {
                    RetireOldAddresses(address);
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public Address GetUserCurrentAddress(string userId)
        {
            return _db.Addresses.FirstOrDefault(u => u.UserId == userId && u.CurrentAddress);
        }

        private bool RetireOldAddresses(Address address)
        {
            try
            {
                List<Address> oldAddresses = _db.Addresses.ToList();
                foreach (var oldAddress in oldAddresses)
                {
                    if (oldAddress.CurrentAddress && oldAddress.UserId == address.UserId && oldAddress.AddressId != address.AddressId)
                    {
                        oldAddress.CurrentAddress = false;
                    }
                }

                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
