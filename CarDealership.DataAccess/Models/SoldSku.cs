namespace CarDealership.DataAccess.Models;

public class SoldSku : CarSku
{
    public DateTime SellingDate { get; set; }
    
    public decimal SellPrice { get; set; }
}