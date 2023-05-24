using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static object instanceLook = new object();

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        private FUFlowerBouquetManagementContext _context = new FUFlowerBouquetManagementContext();
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }
        
        public List<Order> GetAllOrder()
        {
            return _context.Orders.ToList();
        }

        public void DeleteOrder(int id)
        {
            var customer = _context.Orders.Where(c => c.OrderId == id).ToList()[0];
            _context.Orders.Remove(customer);
            _context.SaveChanges();
        }
    }
}
