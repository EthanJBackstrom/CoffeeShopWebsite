using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MyRestaurant.Pages
{
    public class MenuModel : PageModel
    {
        // Add this property
        public List<MenuItem> MenuItems { get; set; }

        public void OnGet()
        {
            // Initialize the MenuItems list with some static data
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Name = "CoffeBeans Arabica", Description = "250g of Beans", Price = 9.99 },
                new MenuItem { Name = "CoffeBeans", Description = "350g of Coffee Beans", Price = 6.50 },
                new MenuItem { Name = "Coffee Filters", Description = "Coffee Filters for v60", Price = 10.99 }
            };
        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}

