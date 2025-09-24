namespace CarDealership.Core.Models;

public class YearStatsReport
{
    public ModelSellStats[] Stats { get; set; }
    
    public int Year { get; set; }

    public string ModelName { get; set; }
}