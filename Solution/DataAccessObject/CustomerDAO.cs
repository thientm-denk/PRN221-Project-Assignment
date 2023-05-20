using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static object instanceLook = new object();

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        FUFlowerBouquetManagementContext context = new FUFlowerBouquetManagementContext();

        public List<Customer> GetAllCustomer()
        {
            return context.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = context.Customers.Where(c => c.CustomerId == id).ToList()[0];
            context.Customers.Remove(customer);
        }
        public Customer Login(string email, string password)
        {
            var customerLogin = context.Customers.Where(c => c.Email.ToUpper().Equals(email.ToUpper()) && c.Password.Equals(password)).ToList()[0];

            return null;

        }
        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
        public List<Customer> GetCustomerByInformation(int ?id, string ?email, string? cusName, string? city, string? county, DateTime? birthday)
        {
            var customerList = context.Customers.ToList();

            if (id != null)
            {

            }
            if (email != null)
            {

            }
            if (cusName != null)
            {

            }
            if (city != null)
            {

            }
            if (county != null)
            {

            }
            if (birthday != null)
            {

            }
            return customerList;
        }


    }
}
