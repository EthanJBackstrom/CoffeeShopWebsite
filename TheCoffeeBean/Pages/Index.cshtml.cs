using Microsoft.AspNetCore.Mvc.RazorPages;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheCoffeeBean.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        
        
// constructor initzalise the database 
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
            // List for the featured products
        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Take(3)  // limits there to only 3 listed products. 
                .ToListAsync();
        }
    }
}