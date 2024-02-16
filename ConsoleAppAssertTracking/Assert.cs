namespace ConsoleAppAssertTracking;
public abstract class Asset
{
    public string ModelName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double Price { get; set; }
    public string Office { get; set; }
    
    public Asset(string modelName, DateTime purchaseDate, double price, string office)
    {
        ModelName = modelName;
        PurchaseDate = purchaseDate;
        Price = price;
        Office = office;
    }
    
    public bool IsCloseToEndOfLife()
    {
        return (DateTime.Now - PurchaseDate).TotalDays > (3 * 365 - 90);
    }
    
    public ConsoleColor GetEndOfLifeStatus()
    {
        var endOfLifeDate = PurchaseDate.AddYears(3);
        var threeMonthsBeforeEndOfLife = endOfLifeDate.AddMonths(-3);
        var sixMonthsBeforeEndOfLife = endOfLifeDate.AddMonths(-6);

        if (DateTime.Now >= threeMonthsBeforeEndOfLife)
        {
            return ConsoleColor.Red;
        }
        else if (DateTime.Now >= sixMonthsBeforeEndOfLife && DateTime.Now < threeMonthsBeforeEndOfLife)
        {
            return ConsoleColor.Yellow;
        }
        else
        {
            return ConsoleColor.White;
        }
    }

}