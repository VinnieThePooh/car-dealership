using CarDealership.DataAccess;
using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Core.Services;

public class CacheService(IDbContextFactory<CarsContext> factory) : ICacheService
{
    public CarModel[] CarModels { get; private set; } = [];
    
    public async Task LoadCarModels(CancellationToken token = default)
    {
        await using var context = await factory.CreateDbContextAsync(token);
        CarModels = await context.Set<CarModel>().OrderBy(x => x.Name).ToArrayAsync(token);
    }
}