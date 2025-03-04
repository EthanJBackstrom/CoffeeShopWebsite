using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class OrderItem
    {
       
        public int OrderNo { get; set; }
        public int StockID { get; set; }
        public int Quantity { get; set; }

        
        public Product Product { get; set; }
        public OrderHistory OrderHistory { get; set; }
    }
}