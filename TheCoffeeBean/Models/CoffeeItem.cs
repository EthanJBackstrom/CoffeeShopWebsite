namespace CoffeeWebStore.Models;

public class CoffeeItem
{
    public int coffeeId { get; set; }
    public string coffeeName { get; set; }
    public string coffeeDescription { get; set; }
    public decimal coffeePrice { get; set; }
    public string coffeeImage { get; set; }
    public string coffeeCategory { get; set; }
}