using CarDealership.DataAccess.Interfaces;

namespace CarDealership.DataAccess.Models;

/// <summary>
/// Stock Keeping Unit - конкретная товарная единица, конкретной марки и модели
/// </summary>
public abstract class CarSku : IHasId<int>
{
    public int Id { get; set; }
    
    // guid for simplicity
    public string SerialNumber { get; set; }
    
    public DateTime ProductionYear { get; set; }

    // для простоты строкой
    public string? Color { get; set; }
    
    // Комплектация, для простоты строкой

    public string? FeatureSet { get; set; }
    
    public int BrandId { get; set; }

    public int ModelId { get; set; }

    public CarModel CarModel { get; set; }

    public CarBrand CarBrand { get; set; }
}