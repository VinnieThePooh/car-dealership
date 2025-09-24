using CarDealership.DataAccess.Configurations;
using CarDealership.DataAccess.Extensions;
using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Brand = CarDealership.DataAccess.Infrastructure.CarBrand;
using CarBrand = CarDealership.DataAccess.Models.CarBrand;

namespace CarDealership.DataAccess;

public class CarsContext(DbContextOptions<CarsContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarBrandConfiguration());
        modelBuilder.ApplyConfiguration(new CarModelConfiguration());
        modelBuilder.ApplyConfiguration(new SoldSkuConfiguration());
        modelBuilder.ApplyConfiguration(new AvailableSkuConfiguration());
        
        SeedCarModels(modelBuilder);
    }

    
    
    private List<CarModel> SeedCarModels(ModelBuilder modelBuilder)
    {
        var brands = Enum.GetValues<Brand>().Select(b => new CarBrand { Id = (int)b, Name = b.ToString() });
        modelBuilder.Entity<CarBrand>().HasData(brands);
        
        var list = new List<CarModel>();

        var carId = 1;
        foreach (var brand in brands)
            list.AddRange(CarContextExtensions.CarModels[(Brand)brand.Id].Select(model => new CarModel() { Id = carId++, Name = model, BrandId = brand.Id }));
        modelBuilder.Entity<CarModel>().HasData(list);
        return list;
    }
    
}