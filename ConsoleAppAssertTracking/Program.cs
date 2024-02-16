namespace ConsoleAppAssertTracking;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Asset> assets = new List<Asset>
        {
            new Laptop("MacBook", "Pro 2020", new DateTime(2024, 1, 1), 1200, "USA"),
            new Laptop("Asus", "Spectrum", new DateTime(2022, 1, 1), 1000, "Sweden"),
            new Laptop("Lenovo", "Hero", new DateTime(2021, 7, 1), 900, "Germany"),
            new MobilePhone("Iphone", "12", new DateTime(2024, 1, 1), 800, "USA"),
            new MobilePhone("Samsung", "Galaxy", new DateTime(2023, 10, 1), 900, "Germany"),
            new MobilePhone("Nokia", "3300", new DateTime(2020, 1, 1), 700, "Sweden"),
        };
        
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-10}", 
            "Type", "Brand", "Model", "Office", "Purchase Date", "Price in USD", "Currency", "Local Price Today (SEK)");
        
        foreach (var asset in assets.OrderBy(a => a.GetType().Name).ThenBy(a => a.PurchaseDate))
        {
            Console.ForegroundColor = asset.GetEndOfLifeStatus();
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-10}", 
                asset.GetType().Name, asset.Brand, asset.ModelName, asset.Office, asset.PurchaseDate.ToString("d"),
                asset.Price, asset.GetCurrencyBasedOnOffice(), asset.LocalPriceToday);
        }
        Console.ResetColor();
    }
    
}