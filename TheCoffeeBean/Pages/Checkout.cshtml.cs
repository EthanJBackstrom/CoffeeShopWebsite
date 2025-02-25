using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoffeeBean.Pages
{
    public class CartCheckout : PageModel
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            var basketData = HttpContext.Session.GetString("CartSession");

            if (!string.IsNullOrEmpty(basketData))
            {
                Items = JsonConvert.DeserializeObject<List<CartItem>>(basketData) ?? new();
            }

            TotalPrice = Items.Sum(i => i.Price * i.Quantity);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpContext.Session.Remove("CartSession");
            TempData["Message"] = "confirmation soon.";
            
            await Task.Delay(500);
            return RedirectToPage("OrderSuccess");
        }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
