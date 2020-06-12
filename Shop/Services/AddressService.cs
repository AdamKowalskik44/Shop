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
    }
}
