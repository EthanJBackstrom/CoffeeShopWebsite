using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TheCoffeeBean.Data.Models
{



    public class OrderHistory
    {
        [Key]
        public int OrderNo { get; set; }
        public string Email { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        

    }
}