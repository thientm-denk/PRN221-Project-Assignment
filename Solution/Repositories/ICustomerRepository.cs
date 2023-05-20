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
        public Customer GetCustomerById(int id);
        public List<Customer> GetCustomerByInformation(int? id, string? email, string? cusName, string? city,
            string? county, DateTime? birthday);

        public Customer Login(string email, string password);
        public string UpdateCustomer(Customer oldCustomer,string email,string oldPassword, string password, string confirmPass, string name, string city, string country, DateTime ?birthday);
        public string CreateCustomer(string email, string password, string confirmPass, string name, string city, string country, DateTime ?birthday);
    }
}