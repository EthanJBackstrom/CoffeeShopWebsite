namespace CoffeeWebStore.Models;

public class Order
{
    public int orderId { get; set; }
    public int userId { get; set; }
    public DateTime OrderDate { get; set; }
    
    public User User { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    
}