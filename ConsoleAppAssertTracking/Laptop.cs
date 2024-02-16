namespace ConsoleAppAssertTracking;

public class Laptop : Asset
{
    public string Brand { get; set; }

    public Laptop(string brand, string modelName, DateTime purchaseDate, double price, string office)
        : base(brand, modelName, purchaseDate, price, office)
    {
        Brand = brand;
    }
}