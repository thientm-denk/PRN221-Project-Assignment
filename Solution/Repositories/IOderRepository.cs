using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IOderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId);
    }
}