namespace Greggs.Products.Application.Models;

public class Product
{
    public Product() { }
    public Product(Product p) 
    { 
        Name = p.Name;
        PriceInPounds = p.PriceInPounds;
    }
    public string Name { get; set; }
    public decimal PriceInPounds { get; set; }
    public decimal PriceInCurrency { get; set; }
}