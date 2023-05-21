using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CustomerDao
    {
        private static CustomerDao instance = null;
        private static object instanceLook = new object();

        public static CustomerDao Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDao();
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
            var maxId = context.Customers.Max(c => c.CustomerId);
            customer.CustomerId = maxId + 1;

            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = context.Customers.Where(c => c.CustomerId == id).ToList()[0];
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        
        public Customer GetCustomerById(int id)
        {
            var customer = context.Customers.Where(c => c.CustomerId == id).ToList()[0];
            return customer;
        }
        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
        public Customer Login(string email, string password)
        {
            var customerLogin = context.Customers.Where(c => c.Email.ToUpper().Equals(email.ToUpper()) && c.Password.Equals(password)).ToList()[0];

            return null;

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
