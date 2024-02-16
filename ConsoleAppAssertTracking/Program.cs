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
            new Laptop("MacBook", "Pro 2020", new DateTime(2024, 1, 1), 1200, "Office1"),
            new Laptop("Asus", "Spectrum", new DateTime(2022, 1, 1), 1000, "Office2"),
            new Laptop("Lenovo", "Hero", new DateTime(2021, 7, 1), 900, "Office3"),
            new MobilePhone("Iphone", "12", new DateTime(2024, 1, 1), 800, "Office1"),
            new MobilePhone("Samsung", "Galaxy", new DateTime(2023, 10, 1), 900, "Office2"),
            new MobilePhone("Nokia", "3300", new DateTime(2020, 1, 1), 700, "Office3"),
        };
        
        foreach (var asset in assets.OrderBy(a => a.GetType().Name).ThenBy(a => a.PurchaseDate))
        {
            Console.ForegroundColor = asset.GetEndOfLifeStatus();
            Console.WriteLine($"{asset.GetType().Name} {asset.ModelName} {asset.PurchaseDate}");
        }
        Console.ResetColor();
    }
    
}