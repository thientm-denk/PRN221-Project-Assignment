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
    }
}