using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IOderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailById(int orderId);
    }
}