/// <summary>
/// Customer Database Context :
/// Connect with SQL server
/// seed some data into the Database
/// Author: Martina Rizk & Sohail Umer
/// Date: August 5, 2020
/// </summary>

using Microsoft.EntityFrameworkCore;
using System;
using System.Resources;
using TableReady.Group5.Domain;
using System.IO;

namespace TableReady.Group5.Data
{
    public class CustomersContext : DbContext
    {
        public CustomersContext() : base() { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<WaitList> waitLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=TableReadyCustomer;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<Customer>().HasData(
                new Customer {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Robert",
                    Email = "John@gmail.com",
                    Password = "password",
                    City = "Vancouver",
                    State = "BC",
                    ZipCode = "14t6f"
                },
                new Customer
                {
                    ID = 2,
                    FirstName = "Rose",
                    LastName = "Wilson",
                    Email = "Rose@gmail.com",
                    Password = "password",
                    City = "Calgary",
                    State = "AB",
                    ZipCode = "5r4c1d"
                },
                new Customer
                {
                    ID = 3,
                    FirstName = "Sally",
                    LastName = "Smith",
                    Email = "Sally@yahoo.com",
                    Password = "password",
                    City = "Banff",
                    State = "AB",
                    ZipCode = "1e2r3d3"
                },
                new Customer
                {
                    ID = 4,
                    FirstName = "Andrew",
                    LastName = "Jacob",
                    Email = "Andrew@yahoo.com",
                    Password = "password",
                    City = "Edmonton",
                    State = "AB",
                    ZipCode = "t3b5d4"
                });

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant 
                {
                    ID = 1,
                    RestaurantName = "KFC",
                    RestaurantDescription = "Buckets, Feasts, Box Meals and More. Get Original Recipe Chicken Delivered Now!"
                },
                new Restaurant
                {
                    ID = 2,
                    RestaurantName = "A&W",
                    RestaurantDescription = "Looking for some hometown goodness? Take a look at whats going on at your local A&W, stop in and lets us know how we are doing!"
                },
                new Restaurant
                {
                    ID = 3,
                    RestaurantName = "SteakHouse",
                    RestaurantDescription = "Treat yourself to some expertly made steak in either a classic or non-traditional steak house setting."
                },
                new Restaurant
                {
                    ID = 4,
                    RestaurantName = "Taco Bell",
                    RestaurantDescription = "Fast-food chain serving Mexican-inspired fare such as tacos, quesadillas & nachos."
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ID = 1,
                    ReservationDate = new DateTime(2020, 5, 15, 13, 45, 0),
                    ReservationStatus = "Accept",
                    CustomerID = 1,
                    RestaurantID = 3
                },
                new Reservation
                {
                    ID = 2,
                    ReservationDate = new DateTime(2020, 08, 08, 16, 45, 0),
                    ReservationStatus = "Accept",
                    CustomerID = 2,
                    RestaurantID = 4
                });

            // Author: Sohail Umer
            modelBuilder.Entity<Reward>().HasData(
                new Reward { ID = 1, CustomerID = 2, RestaurantID = 1, Points = 20, Discount = 5, IsChecked = false, FreeProduct = "drink" },
                new Reward { ID = 2, CustomerID = 3, RestaurantID = 4, Points = 50, Discount = 2, IsChecked = false, FreeProduct = "" },
                new Reward { ID = 3, CustomerID = 4, RestaurantID = 2, Points = 10, Discount = 1, IsChecked = false, FreeProduct = "desert" },
                new Reward { ID = 4, CustomerID = 1, RestaurantID = 1, Points = 25, Discount = 0, IsChecked = false, FreeProduct = "drink" }); ;

            modelBuilder.Entity<WaitList>().HasData(
                new WaitList { ID = 1, Position = 2, CustomerID = 3, RestaurantID = 1 },
                new WaitList { ID = 2, Position = 5, CustomerID = 1, RestaurantID = 2 },
                new WaitList { ID = 3, Position = 4, CustomerID = 2, RestaurantID = 3 });
        }          
    }
}
