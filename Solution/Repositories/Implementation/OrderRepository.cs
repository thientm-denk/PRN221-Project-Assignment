using System;
using System.Collections.Generic;
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

        public List<Order> GetAllOrders()
        {
            return OrderDAO.Instance.GetAllOrder();
        }

        public void DeleteOrder(int id)
        {
            OrderDAO.Instance.DeleteOrder(id);
        }

        public int AddOrder(Order order)
        {
            return OrderDAO.Instance.AddOrder(order);
        }

        public int AddOrder(string customerId, DateTime? shippedDate, string total, string orderStatus,
            out string message)
        {
            message = "";
            if (string.IsNullOrEmpty(orderStatus))
            {
                message = "Status cannot empty";
                return -1;
            }
            if (string.IsNullOrEmpty(customerId) )
            {
                message = "Customer cannot empty";
                return -1;
            }
            if (string.IsNullOrEmpty(total))
            {
                message = "Total cannot empty";
                return -1;
            }

            int customerIdTmp = -1;
            int totalTmp = -1;
            try
            {
                customerIdTmp = int.Parse(customerId);
                totalTmp = int.Parse(total);
            }
            catch (Exception e)
            {
                message = "Input number not valid";
                return -1;
            }

            return OrderDAO.Instance.AddOrder(new Order()
            {
                CustomerId = customerIdTmp,
                OrderDate = DateTime.Now,
                OrderStatus = orderStatus,
                ShippedDate = shippedDate,
                Total = totalTmp,
            });
        }

        public int UpdateOrder(Order oldOrder, string customerId, DateTime? shippedDate, string total,
            string orderStatus,
            out string message)
        {
            var orderUpdate = oldOrder;

            message = "";
            if (string.IsNullOrEmpty(orderStatus) )
            {
                message = "Status cannot empty";
                return -1;
            }
            if (string.IsNullOrEmpty(customerId) )
            {
                message = "Customer cannot empty";
                return -1;
            }
            if (string.IsNullOrEmpty(total))
            {
                message = "Total cannot empty";
                return -1;
            }

            int customerIdTmp;
            int totalTmp;
            try
            {
                customerIdTmp = int.Parse(customerId);
                totalTmp = int.Parse(total);
            }
            catch (Exception e)
            {
                message = "Input number not valid";
                return -1;
            }

            orderUpdate.CustomerId = customerIdTmp;
            orderUpdate.OrderDate = DateTime.Now;
            orderUpdate.OrderStatus = orderStatus;
            orderUpdate.ShippedDate = shippedDate;
            orderUpdate.Total = totalTmp;
            OrderDAO.Instance.Update(orderUpdate);
            return orderUpdate.OrderId;
        }
    }
}