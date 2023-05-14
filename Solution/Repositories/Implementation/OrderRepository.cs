﻿using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return OrderDAO.Instance.GetOrdersByCustomer(customerId);
        }
    }
}