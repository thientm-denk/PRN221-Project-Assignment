
using System.Collections.Generic;
using System.Linq;
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
        private readonly FUFlowerBouquetManagementContext _context = new FUFlowerBouquetManagementContext();
        public List<FlowerBouquet> GetAllFlower()
        {
            return _context.FlowerBouquets.ToList();
        } 
        
        public void AddFlower(FlowerBouquet flower)
        {
            var maxId = _context.FlowerBouquets.Max(c => c.FlowerBouquetId);
            flower.FlowerBouquetId = maxId + 1;

            _context.FlowerBouquets.Add(flower);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var flower = _context.FlowerBouquets.Where(c => c.FlowerBouquetId == id).ToList()[0];
            _context.FlowerBouquets.Remove(flower);
            _context.SaveChanges();
        }
        
        public FlowerBouquet GetCustomerById(int id)
        {
            var flower = _context.FlowerBouquets.Where(c => c.FlowerBouquetId == id).ToList()[0];
            return flower;
        }
        public void UpdateCustomer(FlowerBouquet flower)
        {
            _context.FlowerBouquets.Update(flower);
            _context.SaveChanges();
        }
        public string GetFlowerName(int id)
        {
            return _context.FlowerBouquets.Where(p => p.FlowerBouquetId == id).ToList()[0].FlowerBouquetName;
        } 
    }
}
