using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data;

namespace TheCoffeeBean.Pages
{
    public class Checkoutmodel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<CheckoutItem> Items {get; private set;}

        public decimal Total;
        public long AmountPayable;

        public Checkoutmodel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = UserManager;
            
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            CheckoutCustomer customer = await _db.CheckoutCusomters.FindAsync(user.Email);
            
            Items = _db.CheckoutItems.FromSqlRaw(
                "SELECT FoodItem.ID, FoodItem.Price, " +
                "FoodItem.Item_name" +
                "BasketItem INNER JOIN BasketItems" +
                "ON FoodItem.ID = BasketItems.StockID" +
                "WHERE BasketID = {0}", customer.BasketID
                ).TOList();
                
                Total = 0;

                foreach (var item in Items)
                {
                    Total += (item.Quantity * item.Price);
                }
                AmountPayable = Total;
            
        }

    }
}

