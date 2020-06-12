using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Data.Enums;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return order;
        }

        public List<Order> GetActiveOrders(string userId)
        {
            List<Order> orders = _db.Orders.ToList();
            List<Order> result = new List<Order>();

            foreach (var order in orders)
            {
                if (order.UserId == userId && order.OrderStatus != OrderStatus.sent)
                {
                    result.Add(order);
                }
            }

            return result;
        }

        public List<Order> GetArchiveOrders(string userId)
        {
            List<Order> orders = _db.Orders.ToList();
            List<Order> result = new List<Order>();

            foreach (var order in orders)
            {
                if (order.UserId == userId && order.OrderStatus == OrderStatus.sent)
                {
                    result.Add(order);
                }
            }

            return result;
        }
    }
}
