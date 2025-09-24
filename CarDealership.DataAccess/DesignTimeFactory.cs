using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarDealership.DataAccess;

public class DesignTimeFactory : IDesignTimeDbContextFactory<CarsContext>
{
    public CarsContext CreateDbContext(string[] args)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "CarsDb.db");
        var builder = new DbContextOptionsBuilder<CarsContext>();
        builder.UseSqlite($"Filename={path}");
        return new CarsContext(builder.Options);
    }
}