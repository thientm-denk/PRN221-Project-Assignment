using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailById(int orderId)
        {
            return OderDetailDao.Instance.GetOrderDetailByOrderId(orderId);
        }

        public void AddOrderDetails(List<OrderDetail> orderDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}