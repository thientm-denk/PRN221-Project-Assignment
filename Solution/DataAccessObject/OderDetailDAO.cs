
using System.Collections.Generic;
using System.Linq;
using BussinessObject.Models;

namespace DataAccessObject
{
    public class OderDetailDAO
    {
        private static OderDetailDAO instance = null;
        private static object instanceLook = new object();

        public static OderDetailDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        
        private FUFlowerBouquetManagementContext _context = new FUFlowerBouquetManagementContext();
        public List<OrderDetail> GetOrdersByCustomer(int orderId)
        {
            return _context.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        }

    }
}
