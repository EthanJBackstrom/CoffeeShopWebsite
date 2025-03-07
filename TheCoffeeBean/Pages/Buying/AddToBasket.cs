using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheCoffeeBean.Pages
{
    public class AddToBasketModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AddToBasketModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public int StockID { get; set; }

        [BindProperty]
        public int Quantity { get; set; } = 1;

        public async Task<IActionResult> OnPostAsync()
        {
            
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

          
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserId == user.Email);
            if (basket == null)
            {
                basket = new Basket { UserId = user.Email };
                _context.Baskets.Add(basket);
                await _context.SaveChangesAsync(); 
            }

           
            var basketItem = await _context.BasketItems
                .FirstOrDefaultAsync(bi => bi.BasketID == basket.BasketID && bi.StockID == StockID);

            if (basketItem != null)
            {
               
                basketItem.Quantity += Quantity;
            }
            else
            {
               
                basketItem = new BasketItem
                {
                    BasketID = basket.BasketID,
                    StockID = StockID,
                    Quantity = Quantity
                };
                _context.BasketItems.Add(basketItem);
            }

            
            await _context.SaveChangesAsync();

           
            return RedirectToPage("/Menu");
        }
    }
}
