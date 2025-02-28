using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data
{
    public class OrderItems
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int StockId { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}