using Bogus;
using CarDealership.DataAccess.Infrastructure;
using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.DataAccess.Extensions;
using Brand = CarDealership.DataAccess.Infrastructure.CarBrand;

public static class CarContextExtensions
{
    public static async Task<bool> TrySeedSoldCars(this CarsContext context, int count = 1000)
    {
        var actual = await context.Set<SoldSku>().CountAsync();
        if (actual > 0)
            return false;
        
        var models = await context.Set<CarModel>().ToListAsync();
        var data = GenerateCarData(models, count);
        context.AddRange(data);
        await context.SaveChangesAsync();
        return true;
    }
    
    private static List<SoldSku> GenerateCarData(List<CarModel> models, int count = 1000)
    {
        Randomizer.Seed = new Random(8675309);
        
        var colors = Enum.GetValues<CarColor>().Select(x => x.ToString());
        var featureSets = Enum.GetValues<CarFeatureSet>().Select(x => x.ToString());

        var dateRange = (DateTime.Now.AddYears(-5), DateTime.Now);
        var carIds = 1;
        var testCars = new Faker<SoldSku>()
            .StrictMode(false)
            .RuleFor(s => s.Id, f => carIds++)
            .RuleFor(s => s.Color, f => f.PickRandom(colors))
            .RuleFor(s => s.SerialNumber, f => Guid.NewGuid().ToString())
            .RuleFor(s => s.ModelId, (f, sku) =>
            {
                // both model and brand ids
                var model = f.PickRandom(models);
                sku.ModelId = model.Id;
                sku.BrandId = model.BrandId;
                
                return model.Id;
            })
            .RuleFor(x => x.ProductionYear, (f, sku) =>
            {
                var date = f.Date.Between(dateRange.Item1, dateRange.Now);
                sku.ProductionYear = date;
                sku.SellingDate = f.Date.Between(date, dateRange.Now);
                return date;
            })
            .RuleFor(x => x.FeatureSet, f => f.PickRandom(featureSets))
            .RuleFor(x => x.SellPrice, f => decimal.Parse(f.Commerce.Price(1000000M, 10_000_000M)));

        return testCars.Generate(count);
    }
    
    

    public static Dictionary<Brand, string[]> CarModels = new()
    {
        {
            Brand.Bmw,
            [
                "BMW E30 M3",
                "BMW X5",
                "BMW X6",
                "BMW M1",
                "BMW M2"
            ]
        },
        {
            Brand.Mercedes,
            [
                "Mercedes-Benz GLE",
                "Mercedes-Benz S-Class",
                "Mercedes C-Class",
                "Mercedes-AMG GT",
                "Mercedes GLA-Class"
            ]
        },
        {
            Brand.Audi,
            [
                "Audi A3",
                "Audi A5",
                "Audi Q5",
                "Audi Q3",
                "Audi TT"
            ]
        },
        {
            Brand.Volkswagen,
            [
                "Volkswagen Golf",
                "Volkswagen Passat",
                "Volkswagen Tiguan",
                "Volkswagen Jetta",
                "Volkswagen Touareg"
            ]
        },
        {
            Brand.Peugeot,
            [
                "Peugeot 208 hatchback",
                "Peugeot 3008 SUV",
                "Peugeot 206",
                "Peugeot 3008",
                "Peugeot 308"
            ]
        },
        {
            Brand.Toyota,
            [
                "Toyota Camry",
                "Toyota Corolla",
                "Toyota RAV4",
                "Toyota Tundra",
                "Toyota Land Cruiser",
                "Toyota Tacoma",
                "Toyota Prius",
            ]
        },
        {
            Brand.Honda,
            [
                "Honda Accord",
                "Honda Civic Hybrid",
                "Honda CR-V",
                "Honda Odyssey",
                "Honda Prelude",
                "Honda Integra",
            ]
        },
        {
            Brand.Nissan,
            [
                "Nissan Note",
                "Nissan Sunny",
                "Nissan Skyline",
                "Nissan Juke",
                "Nissan Murano",
                "Nissan Qashqai",
            ]
        },
        {
            Brand.Lifan,
            [
                "Lifan X60",
                "Lifan X70",
                "Lifan X80",
                "Lifan 820",
                "Lifan Maiwei",
            ]
        },
    };
}