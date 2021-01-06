using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1,Name="Dominos",Location="Wrocław",Type = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Ala", Location = "Wawa", Type = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Ola", Location = "Poznań", Type = CuisineType.Polish }
            };

        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants                   
                   orderby r.Name
                   select r;
        }
    }

}

