using Microsoft.EntityFrameworkCore;

namespace TheCoffeeBean.Data.Models
{
    [Keyless]
    public class CheckoutItem
    {
        public int StockID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}