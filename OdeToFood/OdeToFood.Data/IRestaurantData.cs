using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);   
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() { 
                new Restaurant { Id = 1, Name = "Mexicana", Location = "Texas", Description = "The best Mexican Food!", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Taste of China", Location = "China Town", Description = "The best Chinese Food!", Cuisine=CuisineType.Chinese },
                new Restaurant { Id = 3, Name = "Bombay Bites", Location = "Bombay", Description = "The best Indian Food!", Cuisine=CuisineType.Indian }

            };

        }

        public Restaurant Add(Restaurant newRestaurant) {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id)+1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {

            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit() {
            return 0;
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Id
                   select r;
        }
    }
}
