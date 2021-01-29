using OdeToFood.Core;
using System.Collections.Generic;
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
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newResturant);
        Restaurant Delete(int id);
        int Commit();

    }
}

