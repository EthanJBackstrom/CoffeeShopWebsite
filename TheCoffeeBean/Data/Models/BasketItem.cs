using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCoffeeBean.Data.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int BasketID { get; set; }
        
        [Required]
        public int StockID { get; set; }
        
        public int Quantity { get; set; } = 1;
        
        
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}