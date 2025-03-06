using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class OrderHistory
    {
        [Key]
        public int OrderNo { get; set; }  

        public string Email { get; set; } = string.Empty;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}