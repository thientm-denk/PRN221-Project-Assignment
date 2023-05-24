﻿using System;
using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetOrdersByCustomer(int customerId);
        public List<Order> GetAllOrders();
        public void DeleteOrder(int id);
        public int AddOrder(Order order);
        public int AddOrder(string customerId, DateTime? shippedDate, string total, string orderStatus, out string message);
        
        public int UpdateOrder(Order oldOrder,string? customerId, DateTime? shippedDate, string? total, string orderStatus,  out string message);

    }
}