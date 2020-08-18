/// <summary>
/// Customer Manager Class
/// GetAll() , Add() , update() , find()
/// Author: Martina Rizk
/// Data: August 6, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using TableReady.Group5.Data;
using TableReady.Group5.Domain;

namespace TableReady.Group5.BLL
{
    public class CustomerManager
    {
        // Get all the customer as a list
        public static List<Customer> GetAll()
        {
            var context = new CustomersContext();
            var customers = context.Customers.ToList();
            return customers;
        }

        // Add new Customer
        public static void Add(Customer customer)
        {
            var context = new CustomersContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        // update registered customer's data
        public static void Update(Customer customer)
        {
            var context = new CustomersContext();
            var originalCustomer = context.Customers.Find(customer.ID);
            originalCustomer.FirstName = customer.FirstName;
            originalCustomer.LastName = customer.LastName;
            originalCustomer.Email = customer.Email;
            originalCustomer.Password = customer.Password;
            originalCustomer.City = customer.City;
            originalCustomer.State = customer.State;
            originalCustomer.ZipCode = customer.ZipCode;
            context.SaveChanges();
        }

        // find customer by email
        public static Customer Find(string email)
        {
            var context = new CustomersContext();
            var customer = context.Customers.Find(email);
            return customer;
        }
    }
}
