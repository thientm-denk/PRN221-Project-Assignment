using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;

namespace DataAccessObject
{
    public class FlowerBouquetDAO
    {
        private static FlowerBouquetDAO instance = null;
        private static object instanceLook = new object();

        public static FlowerBouquetDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new FlowerBouquetDAO();
                    }
                    return instance;
                }
            }
        }
        private FUFlowerBouquetManagementContext _context = new FUFlowerBouquetManagementContext();
        public List<FlowerBouquet> GetAllFlower()
        {
            return _context.FlowerBouquets.ToList();
        } 
        
    }
}
