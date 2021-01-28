﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    abstract public class AbstracClass
    {
        abstract protected IEnumerable<Restaurant> GetAllTemp();
        abstract protected IEnumerable<Restaurant> GetRestaurantsByNameTemp(string name);

        protected void Temp()
        {
            ///examp
        }
    }
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);        
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant newResturant);
        int Commit();

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1,Name="Dominos",Location="Wrocław",Type = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Mexico Bar", Location = "Warszawa", Type = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Mewa", Location = "Poznań", Type = CuisineType.Polish }
            };

        }

        public Restaurant Add(Restaurant newResturant)
        {
            restaurants.Add(newResturant);
            newResturant.Id = restaurants.Max(x => x.Id) + 1; //just temp

            return newResturant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Type = updatedRestaurant.Type;
            }

            return restaurant;
        }
    }

}

