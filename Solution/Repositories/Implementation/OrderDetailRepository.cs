using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class OrderDetailRepository : IOderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailById(int orderId)
        {
            return OderDetailDao.Instance.GetOrderDetailByOrderId(orderId);
        }
    }
}