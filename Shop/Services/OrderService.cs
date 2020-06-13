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

        public List<Order> GetAllActiveOrders()
        {
            List<Order> orders = _db.Orders.ToList();
            List<Order> result = new List<Order>();

            foreach (var order in orders)
            {
                if (order.OrderStatus != OrderStatus.sent)
                {
                    result.Add(order);
                }
            }

            return result;
        }

        public List<Order> GetAllOrders()
        {
            return _db.Orders.ToList();
        }

        public bool UpdateStatus(Order order)
        {
            try
            {
                var existingOrder = _db.Orders.FirstOrDefault(u => u.OrderId == order.OrderId);
                if (existingOrder != null)
                {
                    existingOrder.OrderStatus = order.OrderStatus;
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
