using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IFlowerBouquetRepository
    {
        public List<FlowerBouquet> GetAllFlower();
        public string GetFlowerName(int id);
        
        public void DeleteFlower(int idCustomer);
        public string UpdateFlower(FlowerBouquet oldFlower,string categoryId,string flowerName, string description, string unitPrice, string unitsInStock, string? flowerBouquetStatus, string? supplierId);
        public string CreateFlower(string categoryId,string flowerName, string description, string unitPrice, string unitsInStock, string? flowerBouquetStatus, string? supplierId);

    }
}