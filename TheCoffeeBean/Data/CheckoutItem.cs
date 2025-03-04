using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCoffeeBean.Data
{
    [NotMapped]
    public class CheckoutItem : PageModel
    {
        
        
            public int StockID { get; set; }
            public string ItemName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

    }
