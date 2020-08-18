/// <summary>
/// Reward Manager Class
/// Author: Sohail Umer
/// Data: August 8, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableReady.Group5.Data;
using TableReady.Group5.Domain;

namespace TableReady.Group5.BLL
{

    public class RewardManager
    {
        //// Get all Rewards as a list
        //public static List<Reward> GetAll()
        //{
        //    var context = new CustomersContext();
        //    var rewards = context.Rewards.ToList();
        //    return rewards;
        //}

        //// Add new Reward
        //public static void Add(Reward reward)
        //{
        //    var context = new CustomersContext();
        //    context.Rewards.Add(reward);
        //    context.SaveChanges();
        //}

        //// update Reward's data
        //public static void Update(Reward reward)
        //{
        //    var context = new CustomersContext();
        //    var originalReward = context.Rewards.Find(reward.ID);
        //    originalReward.Points = reward.Points;
        //    originalReward.Discount = reward.Discount;
        //    originalReward.FreeProduct = reward.FreeProduct;
        //    context.SaveChanges();
        //}
        public List<Restaurant> GetAllResturants()
        {
            using (CustomersContext context = new CustomersContext())
            {
                var result = (from r in context.Restaurants
                              select new Restaurant
                              {
                                  ID = r.ID,
                                  RestaurantName = r.RestaurantName,
                                  RestaurantDescription = r.RestaurantDescription,
                                  RestaurantImage = r.RestaurantImage
                              }).ToList();

                return result;
            }
        }

        public List<Reward> GetAllRewards(int CustomerId)
        {
            using (CustomersContext context = new CustomersContext())
            {
                var result = (from r in context.Rewards.Where(e => e.CustomerID == CustomerId)
                              select new Reward
                              {
                                  ID = r.ID,
                                  RestaurantID = r.RestaurantID,
                                  Discount = r.Discount,
                                  FreeProduct = r.FreeProduct,
                                  Points = r.Points,
                                  CustomerID = r.CustomerID,
                                  IsChecked = r.IsChecked,
                                  CheckedValue = r.IsChecked == true ? "Yes" : "No"
                              }).ToList();

                return result;
            }
        }

        public Customer Login(string UserName, string Password)
        {
            using (CustomersContext context = new CustomersContext())
            {
                var result = (from r in context.Customers.Where(e => e.FirstName.ToLower() == UserName.ToLower() && e.Password.ToLower() == Password.ToLower())
                              select new Customer
                              {
                                  ID = r.ID,
                                  FirstName = r.FirstName,
                                  LastName = r.LastName,
                                  Email = r.Email,
                                  Password = r.Password,
                                  City = r.City,
                                  State = r.State,
                                  ZipCode = r.ZipCode
                              }).FirstOrDefault();

                return result;
            }
        }

        public Reward GetCustomerRewardModel(int customerId, int? ResturantId)
        {
            using (CustomersContext context = new CustomersContext())
            {
                var result = (from r in context.Rewards.Where(e => e.CustomerID == customerId && e.RestaurantID == ResturantId)
                              select new Reward
                              {
                                  ID = r.ID,
                                  RestaurantID = r.RestaurantID,
                                  Discount = r.Discount,
                                  FreeProduct = r.FreeProduct,
                                  Points = r.Points,
                                  CustomerID = r.CustomerID,
                                  IsChecked = r.IsChecked,
                                  CheckedValue = r.IsChecked == true ? "Yes" : "No"
                              }).FirstOrDefault();

                return result;
            }
        }

        public int UpdateCustomerRewardModel(Reward model)
        {
            using (CustomersContext context = new CustomersContext())
            {
                Reward obj = new Reward
                {
                    ID = model.ID,
                    RestaurantID = model.RestaurantID,
                    Discount = model.Discount,
                    FreeProduct = model.FreeProduct,
                    CustomerID = model.CustomerID,
                    IsChecked = model.IsChecked,
                    Points = model.Points
                };

                context.Rewards.Update(obj);
                int result = context.SaveChanges();

                return result;
            }
        }

        public string GetSelectedResturantName(int? resturantId)
        {
            using (CustomersContext context = new CustomersContext())
            {
                var ResturantName = context.Restaurants.FirstOrDefault(e => e.ID == resturantId).RestaurantName;

                return ResturantName;
            }
        }
    }
}