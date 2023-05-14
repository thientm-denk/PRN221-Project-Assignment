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

        public void Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}