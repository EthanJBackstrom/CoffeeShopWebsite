using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheCoffeeBean.Pages
{
    public class MenuModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            // Load all products from the database.
            Products = await _context.Products.ToListAsync();
        }
    }
}