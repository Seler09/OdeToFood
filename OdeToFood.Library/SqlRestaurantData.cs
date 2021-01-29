using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newResturant)
        {
            db.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in db.Restaurants
                        orderby r.Name
                        select r;
            return query;
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count(); //in performance sensitive case i would cash this value
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}

