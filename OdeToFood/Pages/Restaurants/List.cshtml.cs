using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood
{
  public class ListModel : PageModel
  {
    private readonly IConfiguration config;
    private readonly IRestaurantData restaurantData;
    private readonly ILogger<ListModel> logger;

    public string Message { get; set; }
    public string DeleteMessage { get; set; }
    public IEnumerable<Restaurant> Restaurants { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
    {
      this.config = config;
      this.restaurantData = restaurantData;
      this.logger = logger;
    }
    public void OnGet()
    {
      Message = config["SecretMessage"];
      logger.LogInformation("Get request to /List");
      Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
    }
  }
}