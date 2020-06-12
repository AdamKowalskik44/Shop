using Shop.Data;
using Shop.Data.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _db;
        private readonly ProductService productService;

        public CartService(ApplicationDbContext db)
        {
            _db = db;
            productService = new ProductService(_db);
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

        public bool DeleteCartEntry(CartEntry cartEntry)
        {
            try
            {
                _db.CartEntries.Remove(cartEntry);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        public bool SaveCart(List<CartEntry> cartEntries)
        {
            foreach (var cartEntry in cartEntries)
            {
                try
                {
                    CartEntry existingEntry = _db.CartEntries.FirstOrDefault(u => u.CartEntryId == cartEntry.CartEntryId);
                    if (existingEntry != null)
                    {
                        existingEntry.Quantity = cartEntry.Quantity;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            _db.SaveChanges();
            return true;
        }

        public Dictionary<ProductDTO, CartEntry> GetUserCartProducts(string userId)
        {
            List<CartEntry> cartEntries = _db.CartEntries.ToList();
            Dictionary<ProductDTO, CartEntry> result = new Dictionary<ProductDTO, CartEntry>();

            foreach (var cartEntry in cartEntries)
            {
                if (cartEntry.UserId == userId)
                {
                    ProductDTO productDTO = productService.GetProductDTO(cartEntry.ProductId);
                    if (productDTO != null)
                    {
                        result.Add(productDTO, cartEntry);
                    }
                }
            }

            return result;
        }

        public bool IsCartEmpty(string userId)
        {
            List<CartEntry> cartEntries = _db.CartEntries.ToList();
            foreach (var item in cartEntries)
            {
                if (item.UserId == userId)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
