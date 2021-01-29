using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurants != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count()
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

