using OdeToFood.Core;
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
            ///to do
        }
    }
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        IEnumerable<Restaurant> GetRestaurantsById(int id);

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
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsById(int id)
        {
            return from r in restaurants
                   where r.Id.Equals(id)
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }

}

