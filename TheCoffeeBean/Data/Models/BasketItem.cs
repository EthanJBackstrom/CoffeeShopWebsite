
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCoffeeBean.Data.Models
{



    public class BasketItem
    {
        
        public int BasketID { get; set; }
        public int StockID { get; set; }
        public int Quantity { get; set; } = 1;


    }
}