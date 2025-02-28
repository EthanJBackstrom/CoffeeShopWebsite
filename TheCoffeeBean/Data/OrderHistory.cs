using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace TheCoffeeBean.Data;
{
public class OrderHistor
    {
        [Key, Required]
        public int orderNo { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
    
}
