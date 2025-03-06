using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data;
using TheCoffeeBean.Data.Models;
using CheckoutItem = TheCoffeeBean.Data.Models.CheckoutItem;

namespace TheCoffeeBean.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<CheckoutItem> Items {get; private set;}

        public decimal Total { get; private set; }
        public long AmountPayable { get; private set; }

        public CheckoutModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        public async Task OnGetAsync()
        {
            // grab the currently logged in user 
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Items = new List<CheckoutItem>();
                Total = 0;
                AmountPayable = 0;
                return;
            }
            
            //Find by Email 
            CheckoutCustomer customer = await _context.CheckoutCustomers.FindAsync(user.Email);
            if (customer == null)
            {
                Items = new List<CheckoutItem>();
                Total = 0;
                AmountPayable = 0;
                return;
            }
            
            Items = await _context.CheckoutItems.FromSqlRaw(
                "SELECT p.Id as StockID, p.Price, p.Name as ProductName, b.Quantity " +
                "FROM Products p " +
                "INNER JOIN BasketItems b ON p.Id = b.StockID " +
                "WHERE b.BasketID = {0}", customer.BasketID)
                .ToListAsync();

            
            Total = Items.Sum(item => item.Price * item.Quantity);
            AmountPayable = (long)Total;

        }

    }
}

