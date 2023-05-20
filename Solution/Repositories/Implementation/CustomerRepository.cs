﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public string UpdateCustomer(Customer oldCustomer, string email, string password, string confirmPass, string name, string city,
            string country, DateTime? birthday)
        {
            var newCustomer = oldCustomer;
            // Fill all the * information
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                return "Please fill all required information!";
            }
            
            // Email check
            // check for @
            if (!email.Contains("@"))
            {
                return "Email not valid, must contain '@'";
            }

            // check length
            if (email.Length > 30)
            {
                return "Email too long, below 30 character";
            }
           
            // check space
            if (email.Contains(" "))
            {
                return "Email contain special character";
            }

            // check for special character and tail email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                return "Email tail not valid or email contain special character";
            }
            
            // Check other filed 
            if (name.Length > 30)
            {
                return "Name too long, below 30 character";
            }
            if (city.Length > 30)
            {
                return "City too long, below 30 character";
            }
            if (country.Length > 30)
            {
                return "Country too long, below 30 character";
            }
            
            // Passwords don't match
            if (!password.Equals(confirmPass)) return "Password does not match"; 
            
            // Check password criteria
            if (password.Length < 8)
            {
                // Password is too short
                return "Password is too short, at least 8 character";
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                // Password doesn't contain a digit
                return "Password must have at least one digit";
            }

            if (!Regex.IsMatch(password, @"[a-zA-Z]"))
            {
                // Password doesn't contain a letter
                return "Password must have at least one letter";
            }

            // Additional criteria can be added as needed
            return "";
        }
        
        public string CreateCustomer(string email, string password, string confirmPass, string name, string city,
            string country,
            DateTime? birthday)
        {
            
            // Fill all the * information
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                return "Please fill all required information!";
            }
            
            // Email check
            // check for @
            if (!email.Contains("@"))
            {
                return "Email not valid, must contain '@'";
            }

            // check length
            if (email.Length > 30)
            {
                return "Email too long, below 30 character";
            }
           
            // check space
            if (email.Contains(" "))
            {
                return "Email contain special character";
            }

            // check for special character and tail email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                return "Email tail not valid or email contain special character";
            }
            
            // Check other filed 
            if (name.Length > 30)
            {
                return "Name too long, below 30 character";
            }
            if (city.Length > 30)
            {
                return "City too long, below 30 character";
            }
            if (country.Length > 30)
            {
                return "Country too long, below 30 character";
            }
            
            // Passwords don't match
            if (!password.Equals(confirmPass)) return "Password does not match"; 
            
            // Check password criteria
            if (password.Length < 8)
            {
                // Password is too short
                return "Password is too short, at least 8 character";
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                // Password doesn't contain a digit
                return "Password must have at least one digit";
            }

            if (!Regex.IsMatch(password, @"[a-zA-Z]"))
            {
                // Password doesn't contain a letter
                return "Password must have at least one letter";
            }

            // Additional criteria can be added as needed

            
            return "";
        }
    }
}