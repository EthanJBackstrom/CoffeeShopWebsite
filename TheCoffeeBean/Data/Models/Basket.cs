using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    
    } 
}
