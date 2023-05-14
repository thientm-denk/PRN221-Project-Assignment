using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class OrderDetailRepository : IOderDetailRepository
    {
        public List<OrderDetail> GetOrdersByCustomer(int orderId)
        {
            return OderDetailDao.Instance.GetOrdersByCustomer(orderId);
        }
    }
}