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

        public List<Customer> GetCustomerByEmail(string email)
        {
            return context.Customers.Where(cus => cus.Email.ToUpper().Contains(email.ToUpper())).ToList();
        }
        public List<Customer> GetCustomerByCity(string email)
        {
            return context.Customers.Where(cus => cus.City.ToUpper().Contains(email.ToUpper())).ToList();
        }
        public List<Customer> GetCustomerByCountry(string email)
        {
            return context.Customers.Where(cus => cus.Country.ToUpper().Contains(email.ToUpper())).ToList();
        }
        public List<Customer> GetCustomerByName(string name)
        {
            return context.Customers.Where(cus => cus.CustomerName.ToUpper().Contains(name.ToUpper())).ToList();
        }

    }
}
