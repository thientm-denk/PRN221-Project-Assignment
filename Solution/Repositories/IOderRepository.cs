using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId);
        public List<Order> GetAllOrders();
        public void DeleteOrder(int id);
    }
}