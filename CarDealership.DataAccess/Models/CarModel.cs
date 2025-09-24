using CarDealership.DataAccess.Interfaces;

namespace CarDealership.DataAccess.Models;

public class CarModel : IHandbook
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AvailableSku> StockUnits { get; set; } = [];
    
    public List<SoldSku> SoldUnits { get; set; } = [];
    
    public CarBrand CarBrand { get; set; }
    
    public int BrandId { get; set; }
}