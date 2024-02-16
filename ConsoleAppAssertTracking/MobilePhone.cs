namespace ConsoleAppAssertTracking;

public class MobilePhone : Asset
{
    public string Brand { get; set; }

    public MobilePhone(string brand, string modelName, DateTime purchaseDate, double price, string office)
        : base(modelName, purchaseDate, price, office)
    {
        Brand = brand;
    }
}