using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
  public class InMemoryRestaurantData : IRestaurantData
  {
    List<Restaurant> restaurants;
    public InMemoryRestaurantData()
    {
      restaurants = new List<Restaurant>()
      {
        new Restaurant { Id=1, Name="Noel's Best Cuisine", Location="Arizona", Cuisine=CuisineType.Italian },
        new Restaurant { Id=2, Name="Kenzie's Classic", Location="Maine", Cuisine=CuisineType.Indian },
        new Restaurant { Id=3, Name="Brant's South of the Border", Location="Michigan", Cuisine=CuisineType.Mexican }
      };
    }
    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in restaurants
             where string.IsNullOrEmpty(name) || r.Name.ToLower().IndexOf(name.ToLower()) != -1
             orderby r.Name
             select r;
    }
    public Restaurant GetById(int id)
    {
      return restaurants.SingleOrDefault(r => r.Id == id);
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
    public Restaurant Add(Restaurant newRestaurant)
    {
      restaurants.Add(newRestaurant);
      newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
      return newRestaurant;
    }
    public int Commit()
    {
      return 0;
    }
    public Restaurant Delete(int id)
    {
      var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
      if (restaurant != null)
      {
        restaurants.Remove(restaurant);
      }
      return restaurant;
    }

    public int GetCountOfRestaurants()
    {
      return restaurants.Count();
    }
  }
}
