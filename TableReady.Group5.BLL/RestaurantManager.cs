/// <summary>
/// Restaurant Manager Class
/// GetAll() , Add() , update() , find()
/// Author: Martina Rizk
/// Data: August 6, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableReady.Group5.Data;
using TableReady.Group5.Domain;

namespace TableReady.Group5.BLL
{ 
    public class RestaurantManager
    {
        // Get all Restaurants as a list
        public static List<Restaurant> GetAll()
        {
            var context = new CustomersContext();
            var restaurants = context.Restaurants.ToList();
            return restaurants;
        }

        // Add new Restaurant
        public static void Add(Restaurant restaurant)
        {
            var context = new CustomersContext();
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
        }

        // update Restaurant's data
        public static void Update(Restaurant restaurant)
        {
            var context = new CustomersContext();
            var originalRestaurant = context.Restaurants.Find(restaurant.ID);
            originalRestaurant.RestaurantName = restaurant.RestaurantName;
            originalRestaurant.RestaurantDescription = restaurant.RestaurantDescription;
            originalRestaurant.RestaurantImage = restaurant.RestaurantImage;
            context.SaveChanges();
        }
    }
}
