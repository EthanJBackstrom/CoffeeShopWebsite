using Microsoft.EntityFrameworkCore;

namespace TheCoffeeBean.Data.Models
{
    [Keyless]
    // product details when checking out 
    public class CheckoutItem
    {
        // Self explanatory StockID, the name of product, price and quanitity selected when purchasing 
        public int StockID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}