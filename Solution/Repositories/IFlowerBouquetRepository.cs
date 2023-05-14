using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IFlowerBouquetRepository
    {
        public List<FlowerBouquet> GetAllFlower();
    }
}