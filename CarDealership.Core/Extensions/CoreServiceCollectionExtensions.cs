using CarDealership.Core.Services;
using CarDealership.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealership.Core.Extensions;

public static class CoreServiceCollectionExtensions
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddSingleton<ISellReportService, SellReportService>();
        services.AddSingleton<IExportService, ExportService>();
        services.AddSingleton<ICacheService, CacheService>();
        
        var path = Path.Combine(AppContext.BaseDirectory, "CarsDb.db");
        var connectionString = $"Filename={path}";
        
        services.AddDbContextFactory<CarsContext>(f => f.UseSqlite(connectionString));
        return services;
    }
}