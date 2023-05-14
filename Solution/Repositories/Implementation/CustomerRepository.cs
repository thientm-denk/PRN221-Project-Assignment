using System;
using System.Collections.Generic;
using BussinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddNewCustomer(Customer newCustomer)
        {
            CustomerDAO.Instance.AddCustomer(newCustomer);
        }

        public void UpdateCustomer(Customer newCustomer)
        {
            CustomerDAO.Instance.UpdateCustomer(newCustomer);
        }

        public void DeleteCustomer(int idCustomer)
        {
            CustomerDAO.Instance.DeleteCustomer(idCustomer);
        }

        public List<Customer> GetCustomerByInformation(int? id, string email, string cusName, string city,
            string county,
            DateTime? birthday)
        {
            return CustomerDAO.Instance.GetCustomerByInformation(id, email, cusName, city, county, birthday);
        }

        public Customer Login(string email, string password)
        {
            // Check for admin
            if (false)
            {
                return new Customer()
                {
                    CustomerId = -1
                };
            }
            // Customer login
            var customerList = CustomerDAO.Instance.GetAllCustomer();
            foreach (var cus in customerList)
            {
                // Check for email if not -> next customer
                if (cus.Email != email)
                {
                    continue;
                }
                // Check password, if valid --> Return cus
                if (cus.Password == password)
                {
                    return cus;
                }
                
            }
            
            return null;
        }
    }
}