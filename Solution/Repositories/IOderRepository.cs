using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId);
    }
}