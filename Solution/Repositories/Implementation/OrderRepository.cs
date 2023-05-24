using System;
using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return OrderDAO.Instance.GetOrdersByCustomer(customerId);
        }
        
        public List<Order> GetAllOrders()
        {
            return OrderDAO.Instance.GetAllOrder();
        }

        public void DeleteOrder(int id)
        {
            OrderDAO.Instance.DeleteOrder(id);
        }

        public int AddOrder(Order order)
        {
            return OrderDAO.Instance.AddOrder(order);
        }

        public int AddOrder(string customerId, DateTime? shippedDate, string total, string orderStatus, out string message)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order oldOrder, string? customerId, DateTime? shippedDate, string? total, string orderStatus,
            out string message)
        {
            throw new NotImplementedException();
        }
    }
}