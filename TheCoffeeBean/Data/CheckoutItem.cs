using System.ComponentModel.DataAnnotations.schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCoffeeBean.Data
{
    public class CheckoutItem
    {
        [NotMapped]
        public class CheckoutItem
        {
            public int StockID { get; set; }
            public string ItemName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

    }
}