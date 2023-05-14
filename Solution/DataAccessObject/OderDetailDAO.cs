
using System.Collections.Generic;
using System.Linq;
using BussinessObject.Models;

namespace DataAccessObject
{
    public class OderDetailDao
    {
        private static OderDetailDao instance = null;
        private static object instanceLook = new object();

        public static OderDetailDao Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OderDetailDao();
                    }
                    return instance;
                }
            }
        }
        
        private FUFlowerBouquetManagementContext _context = new FUFlowerBouquetManagementContext();
        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        }

    }
}
