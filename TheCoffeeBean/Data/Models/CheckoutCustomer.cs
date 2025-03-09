using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{


// Customer details during checkout 
    public class CheckoutCustomer
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }
        public string Name {get; set;}
        
        public int BasketID { get; set; }
        

    }
}