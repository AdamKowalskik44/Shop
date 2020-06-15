using Shop.Data;
using Shop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _db;
        private readonly OrderService orderService;

        public PaymentService(ApplicationDbContext db)
        {
            _db = db;
            orderService = new OrderService(_db);
        }

        public List<Payment> GetPayments(int orderId)
        {
            List<Payment> result = new List<Payment>();
            List<Payment> payments = _db.Payments.ToList();
            foreach (var payment in payments)
            {
                if (payment.OrderId == orderId)
                {
                    result.Add(payment);
                }
            }
            return result;
        }

        public Order CreatePayment(Payment payment)
        {
            Order order = orderService.GetOrder(payment.OrderId);
            if (order != null)
            {
                order.AmountPaid += payment.TransferValue;
                if (order.AmountPaid >= order.TotalAmount)
                {
                    order.OrderStatus = OrderStatus.paid;
                    order.isPaid = true;
                }
                else if (order.AmountPaid > 0)
                {
                    order.OrderStatus = OrderStatus.partlyPaid;
                }
                order = orderService.UpdateStatusWhileCreatingPayment(order);
                if (order != null)
                {
                    try
                    {
                        _db.Payments.Add(payment);
                        _db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    return order;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
