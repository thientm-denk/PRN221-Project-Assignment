using System;
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

        public string UpdateFlower(FlowerBouquet oldFlower, string categoryId, string flowerName, string description,
            string unitPrice,
            string unitsInStock, string? supplierId)
        {
            // Fill all the * information
           
            if (string.IsNullOrEmpty(categoryId) || string.IsNullOrEmpty(flowerName) ||
                string.IsNullOrEmpty(description) || string.IsNullOrEmpty(unitPrice) ||
                string.IsNullOrEmpty(unitsInStock))
            {
                return "Please fill all required information!";
            }

            var categoryIdTmp = int.Parse(categoryId);
            if (categoryIdTmp == -1)
            {
                return "Please choose category!";
            }

            if (flowerName.Length > 30)
            {
                return "Name too long, below 30 character";
            }

            if (description.Length > 50)
            {
                return "Description too long, below 50 character";
            }

            // check number
            decimal unitPriceTmp;
            int unitsInStockTmp;
            try
            {
                unitPriceTmp = decimal.Parse(unitPrice);
                unitsInStockTmp = int.Parse(unitsInStock);
            }
            catch (Exception)
            {
                return "Unit price or unit in stock not valid";
            }

            var updateFlower = oldFlower;
            updateFlower.CategoryId = categoryIdTmp;
            updateFlower.FlowerBouquetName = flowerName;
            updateFlower.Description = description;
            updateFlower.UnitsInStock = unitsInStockTmp;
            updateFlower.UnitPrice = unitPriceTmp;
            
            FlowerBouquetDAO.Instance.UpdateFlower(updateFlower);
            return "";
        }

        public string CreateFlower(string categoryId, string flowerName, string description, string unitPrice,
            string unitsInStock,
            string? flowerBouquetStatus, string? supplierId)
        {
            return "";
        }
    }
}