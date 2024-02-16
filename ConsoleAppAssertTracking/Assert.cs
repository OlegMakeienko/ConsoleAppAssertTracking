using Newtonsoft.Json;

namespace ConsoleAppAssertTracking;
public abstract class Asset
{
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double Price { get; set; }
    public string Office { get; set; }
    
    public Asset(string brand, string modelName, DateTime purchaseDate, double price, string office)
    {
        Brand = brand;
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
    
    public string GetCurrencyBasedOnOffice()
    {
        var office = this.Office.ToLower();
        if (office == "USA")
        {
            return "USD";
        }
        else if (office == "Sweden")
        {
            return "SEK";
        }
        else
        {
            return "EUR";
        }
    }
    
    public async Task<double> GetExchangeRateToSEK()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://api.exchangerate-api.com/v4/latest/" + this.GetCurrencyBasedOnOffice());
        var data = await response.Content.ReadAsStringAsync();
        var exchangeRates = JsonConvert.DeserializeObject<ExchangeRateResponse>(data);
        return exchangeRates.Rates["SEK"];
    }
    
    public async Task<double> LocalPriceToday()
    {
        var exchangeRate = await GetExchangeRateToSEK();
        return this.Price * exchangeRate;
    }

}