namespace CoffeeWebStore.Models;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; } 
    public int CoffeeId { get; set; } 

    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }

    public Order Order { get; set; }
    public CoffeeItem CoffeeItem { get; set; }
    
}