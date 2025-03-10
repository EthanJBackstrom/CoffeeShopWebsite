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
    [Authorize(Roles = "Admin")] // Only useers with admin role is able toa ccess 
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // list of products 
        public IList<Product> Products { get; set; } = new List<Product>();

      
        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        [BindProperty]
        public Product EditProduct { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }

        // Handles form submission 
        public async Task<IActionResult> OnPostAddProductAsync()
        {
            if (!ModelState.IsValid)
            {
                Products = await _context.Products.ToListAsync();
                return Page();
            }
            
            // adds new product to the database 
            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // Handles deleting a product
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        // fetches the product
        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            EditProduct = await _context.Products.FindAsync(id);
            if (EditProduct == null)
            {
                return NotFound();
            }

            Products = await _context.Products.ToListAsync();
            return Page();
        }

        // Upadtee
        public async Task<IActionResult> OnPostUpdateProductAsync()
        {
            if (!ModelState.IsValid)
            {
                Products = await _context.Products.ToListAsync();
                return Page();
            }

            var productInDb = await _context.Products.FindAsync(EditProduct.Id);
            if (productInDb == null)
            {
                return NotFound();
            }

            // Updates product 
            productInDb.Name = EditProduct.Name;
            productInDb.Description = EditProduct.Description;
            productInDb.Price = EditProduct.Price;
            productInDb.ImageUrl = EditProduct.ImageUrl;

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
