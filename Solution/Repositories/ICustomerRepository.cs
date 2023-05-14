using System;
using System.Collections.Generic;
using BussinessObject.Models;

namespace Repositories
{
    public interface ICustomerRepository
    {
        public void AddNewCustomer(Customer newCustomer);
        public void UpdateCustomer(Customer newCustomer);
        public void DeleteCustomer(int idCustomer);

        public List<Customer> GetCustomerByInformation(int? id, string? email, string? cusName, string? city,
            string? county, DateTime? birthday);

        public Customer Login(string email, string password);
    }
}