using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class FlowerBouquetRepository : IFlowerBouquetRepository
    {
        public List<FlowerBouquet> GetAllFlower()
        {
            return FlowerBouquetDAO.Instance.GetAllFlower();
        }

        public string GetFlowerName(int id)
        {
            return FlowerBouquetDAO.Instance.GetFlowerName(id);
        }

        public void DeleteFlower(int idCustomer)
        {
            
        }

        public string UpdateFlower(FlowerBouquet oldFlower, string categoryId, string flowerName, string description, string unitPrice,
            string unitsInStock, string? flowerBouquetStatus, string? supplierId)
        {
            return "";
        }

        public string CreateFlower(string categoryId, string flowerName, string description, string unitPrice, string unitsInStock,
            string? flowerBouquetStatus, string? supplierId)
        {
            return "";
        }
    }
}