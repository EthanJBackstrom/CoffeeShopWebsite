using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheCoffeeBean.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

      
        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }

     
        public async Task<IActionResult> OnPostAddProductAsync()
        {
            if (!ModelState.IsValid)
            {
                
                Products = await _context.Products.ToListAsync();
                return Page();
            }

            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();

            
            return RedirectToPage();
        }
    }
}