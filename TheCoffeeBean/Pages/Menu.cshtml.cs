using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models;

namespace TheCoffeeBean.Pages
{
    public class MenuModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // search term from query string
        public string? SearchTerm { get; set; }

        // List of items 
        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm;

            var productsQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = await productsQuery
                    .Where(p => p.Name.Contains(SearchTerm) || (p.Description != null && p.Description.Contains(SearchTerm)))
                    .ToListAsync();
            }
            else
            {
                Products = await productsQuery.ToListAsync();
            }
        }
    }
}