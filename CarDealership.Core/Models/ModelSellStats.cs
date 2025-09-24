namespace CarDealership.Core.Models;

public class ModelSellStats
{
    public int ModelId { get; set; }

    public string ModelName { get; set; }

    // 12 values
    // public decimal[] MonthlyStats { get; set; } =  new decimal[12];

    // the hard way
    public decimal JanuaryStats { get; set; }

    public decimal FebruaryStats { get; set; }

    public decimal MarchStats { get; set; }

    public decimal AprilStats { get; set; }

    public decimal MayStats { get; set; }
    
    public decimal JuneStats { get; set; }

    public decimal JulyStats { get; set; }

    public decimal AugustStats { get; set; }

    public decimal SeptemberStats { get; set; }

    public decimal OctoberStats { get; set; }
    
    public decimal NovemberStats { get; set; }

    public decimal DecemberStats { get; set; }
}