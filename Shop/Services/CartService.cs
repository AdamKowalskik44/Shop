using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _db;

        public CartService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddToCart(CartEntry cartEntry)
        {
            CartEntry existingCartEntry = _db.CartEntries.FirstOrDefault(u => u.UserId == cartEntry.UserId && u.ProductId == cartEntry.ProductId);
            if (existingCartEntry == null)
            {
                try
                {
                    _db.CartEntries.Add(cartEntry);
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    existingCartEntry.Quantity += cartEntry.Quantity;
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
